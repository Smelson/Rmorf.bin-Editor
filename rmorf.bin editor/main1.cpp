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

	cout << "Clear file was created!\n";
	cout << "Type frequency of animations. Choose presets: water, flag, clothes, trees:\n";
	string user_choice;
	cin >> user_choice;
	
	if (user_choice == "water") {
		fout.write(FW, 2);
	}

	else if (user_choice == "flag") {
		fout.write(FF, 2);
	}

	else if (user_choice == "clothes") {
		fout.write(FC, 2);
	}

	else if (user_choice == "trees") {
		fout.write(FT, 2);
	}
	
	else {
		cout << "Didn't find preset!\n";
		fout.close();
	}

	
	fout.write(unknown2, 14);
	cout << "How many objects do you need?:\n";
	int i = 0;
	int value = 0;
	cin >> value;
	while(i < value)
	{
		i++;
		cout << "Type name of object from scene2.bin\n";
		string objname;
		cin >> objname;
		fout << objname;
		fout.write(Point, 1);
		cout << "Type name of objects layer with anim(it has MRPH parameter in Boz4ds)\n";
		string meshname;
		cin >> meshname;
		fout << meshname;
		fout.write(Null, 1);
	}
	fout.write(Null, 1);
	fout.write(Null, 1);
	cout << "Done!\n";
	system("pause");
	return 0;
}