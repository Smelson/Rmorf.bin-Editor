#include <iostream>
#include <string>
#include <fstream>

using namespace std;

// Consts #1
#define fileSize "\x00\x00\x00\x00"
#define key "\xCD\xCC\xCC\x3D"
#define dontknow1 "\x01\x00\x00\x00"
#define morfCount "\x00\x00"
#define morfDesc1 "\x00"
#define morfDescN "\x00"
#define unknown "\x80\x00\x00\x00"

// Consts #2
const char* Point = "\x2E";
const char* Null = "\x00";
const char* FW = "\x18\x00";
const char* FF = "\xA0\x00";
const char* FC = "\xE8\x03";
const char* FT = "\x64\x00";
const char* unknown2 = "\x00\x00\x01\x00\x00\x00\x01\x00\x00\x00\x01\x00\x00\x00";

int main()
{
    // Creating a file
    ofstream fout;
    fout.open("rmorf.bin", ios_base::out);

    // Writing consts that are defined above
    fout.write(fileSize, 4);
    fout.write(key, 4);
    fout.write(dontknow1, 4);
    fout.write(morfCount, 2);
    fout.write(morfDesc1, 1);
    fout.write(morfDescN, 1);
    fout.write(unknown, 4);

    // Choosing preset that we need
    char user_choice;
    UserChoice:
    cout << "Choose a preset that you need: c - clothes or f - flags" << endl;
    cin >> user_choice;

    switch (user_choice) {
        // case 'w':
        //    fout.write(FW, 2);
        //    cout << "Count of objects: " << endl;
        //    break;
    case 'f':
        fout.write(FF, 2);
        cout << "Count of objects: " << endl;
        break;
    case 'c':
        fout.write(FC, 2);
        cout << "Count of objects: " << endl;
        break;
        //case 't':
        //  fout.write(FT, 2);
        //  cout << "Count of objects: " << endl;
        //  break;
    default:
        cout << "Couldn't find preset, try again!" << endl;
        goto UserChoice;
        break;
    }

    // Writing "unknown2" const
    fout.write(unknown2, 14);
    int i = 0;
    int value;
    cin >> value;

    // Choosing name of object and name of objects layer with anim
    while (i < value) {
        i++;
        cout << "Name of object in scene2.bin: " << endl;

        string objname, meshname;
        cin >> objname;

        cout << "Type name of objects layer with anim (it has MRPH parameter in Boz4ds)" << endl;
        cin >> meshname;

        fout << objname;
        fout.write(Point, 1);

        fout << meshname;
        fout.write(Null, 1);
    }

    fout.write(Null, 1);
    fout.write(Null, 1);

    // Writing count of objects on 12th shift
    unsigned char* valptr = (unsigned char*)&value;
    fout.seekp(12);
    fout << valptr;

    // Writing size of file on file's start and save it
    fout.seekp(0);
    fstream file("rmorf.bin");
    int size = 0;
    file.seekg(0, std::ios::end);
    size = file.tellg();
    unsigned char* file_size = (unsigned char*)&size;
    fout << file_size;
    fout.close();

    cout << "DONE BLYAD!";

    return 0;
}

