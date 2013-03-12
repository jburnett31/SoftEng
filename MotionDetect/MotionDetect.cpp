#include <opencv2/opencv.hpp>
#include <iostream>
#include <time.h>
#include <dirent.h>
#include <sstream>
#include <dirent.h>
#include <sys/types.h>
#include <sys/stat.h>

using namespace std;
using namespace cv;

bool directoryExists( const char* pzPath )
{
    if ( pzPath == NULL) return false;
    DIR *pDir;
    bool bExists = false;
    pDir = opendir (pzPath);
    if (pDir != NULL)
    {
        bExists = true;
        (void) closedir (pDir);
    }
    return bExists;
}

bool saveImg(Mat image, const string DIRECTORY, const string EXTENSION, const char * DIR_FORMAT, const char * FILE_FORMAT){

    stringstream ss;
    time_t seconds;
    struct tm * timeinfo;
    char TIME[80];

    time (&seconds);
    timeinfo = localtime (&seconds);

    // convert dir...
    strftime (TIME,80,DIR_FORMAT,timeinfo);
    ss.str("");
    ss << DIRECTORY << TIME;

    if(!directoryExists(ss.str().c_str()))
        mkdir(ss.str().c_str(), 0777);

    // convert image name
    strftime (TIME,80,FILE_FORMAT,timeinfo);
    ss.str("");
    ss << DIRECTORY << TIME << EXTENSION;

    // save image
    return imwrite(ss.str().c_str(), image);
}

int main (int argc, char * const argv[]){

    // const
    const string DIR = "./pics/";
    const string EXT = ".jpg";
    const int DELAY = 700; // mseconds

    string DIR_FORMAT = "%d%h%Y";
    string FILE_FORMAT = DIR_FORMAT + "/" + "%d%h%Y_%H%M%S";

    // create all necessary instances
    CvCapture * camera = cvCaptureFromCAM(CV_CAP_ANY);
    Mat original =  cvQueryFrame(camera);
    Mat next_frame = original;
    Mat current_frame = cvQueryFrame(camera);
    Mat prev_frame = cvQueryFrame(camera);

    cvtColor(current_frame, current_frame, CV_RGB2GRAY);
    cvtColor(prev_frame, prev_frame, CV_RGB2GRAY);
    cvtColor(next_frame, next_frame, CV_RGB2GRAY);

    Mat d1, d2, result;
    int window = 200;
    bool movement;
    while (true){

        movement = false;
        absdiff(next_frame, current_frame, d1);
        absdiff(current_frame, prev_frame, d2);
        bitwise_xor(d1, d2, result);

        int middle_y = result.rows/2;
        int middle_x = result.cols/2;

        // Center window
        threshold(result, result, 140, 255, CV_THRESH_BINARY);
        for(int i = middle_x-window; i < middle_x+window; i++)
            for(int j = middle_y-window; j < middle_y+window; j++)
                if(result.at<int>(j,i)>0)
                {
                    movement = true;
                    break;
                }

        if(movement==true)
            saveImg(original,DIR,EXT,DIR_FORMAT.c_str(),FILE_FORMAT.c_str());

        imshow("Motion", result);

        prev_frame = current_frame;
        current_frame = next_frame;

        // get image from webcam
        next_frame = cvQueryFrame(camera);
        cvtColor(next_frame, next_frame, CV_RGB2GRAY);

        // semi delay and quit when press Q/q
        int key = cvWaitKey (DELAY);
        if (key == 'q' || key == 'Q')
            break;
    }

        return 0;
}
