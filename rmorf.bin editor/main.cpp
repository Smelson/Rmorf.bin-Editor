#include <iostream>
#include <string>
#include <fstream>

using namespace std;

#define fileSize "\x00\x00\x00\x00"
#define key "\xCD\xCC\xCC\x3D"
#define dontknow1 "\x01\x00\x00\x00"
#define morfCount "\x00\x00"
#define morfDesc1 "\x00"
#define morfDescN "\x00"
#define unknown "\x80\x00\x00\x00"

const char* Point = "\x2E";
const char* Null = "\x00";
const char* FW = "\x18\x00";
const char* FF = "\xA0\x00";
const char* FC = "\xE8\x03";
const char* FT = "\x64\x00";
const char* unknown2 = "\x00\x00\x01\x00\x00\x00\x01\x00\x00\x00\x01\x00\x00\x00";

int main()
{
    ofstream fout;
    fout.open("rmorf.bin", ios_base::out);
    fout.write(fileSize, 4); 
    fout.write(key, 4); 
    fout.write(dontknow1, 4); 
    fout.write(morfCount, 2); 
    fout.write(morfDesc1, 1); 
    fout.write(morfDescN, 1); 
    fout.write(unknown, 4);

    char user_choice;
    cout << "Choose a preset that you need: w - water, c - clothes, t - trees, f - flags" << endl;
    cin >> user_choice;

    switch (user_choice) {
    case 'w':
        fout.write(FW, 2);
        cout << "Count of objects: " << endl;
        break;
    case 'f':
        fout.write(FF, 2);
        cout << "Count of objects: " << endl;
        break;
    case 'c':
        fout.write(FC, 2);
        cout << "Count of objects: " << endl;
        break;
    case 't':
        fout.write(FT, 2);
        cout << "Count of objects: " << endl;
        break;
    default:
        cout << "Couldn't find preset!";
        fout.close();
        break;
    }

    
    fout.write(unknown2, 14);
    int i = 0;
    int value;
    cin >> value;

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

    unsigned char* valptr = (unsigned char*)&value;
    fout.seekp(12);
    fout << valptr;

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

