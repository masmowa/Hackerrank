// array_LeftShift.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <cstdio>
#include <ostream>
#include <fstream>
#include <algorithm>
#include <vector>
#include <functional>
#include <sstream>
//#define _HAS_CXX17
#include <filesystem>

using namespace std;

#define MAS_TEST 1
#include "parseUtil.h"

bool lShiftVector(std::vector<int>& vec, int count)
{
	bool result = false;
	int test = vec[0];
	int zz = 0;
	int k = 0;
	for (; k < count; ++k) {
		for (int i = 0; i < vec.size() - 1; ++i) {
			vec[i] = vec[i+1];
		}
		vec[vec.size()-1] =(test);
//		print_vector(vec);
		test = vec[0];
	}
	return (k == count);
}
int main()
{

	efs::path input("input");
	//efs::path inputFileName("input0.txt");
	efs::path inputFileName("input00.txt");
	efs::path full_path = efs::current_path() / "input" / inputFileName;
	if (Verbose())
	{

		std::cout << full_path << std::endl;
		//std::cout << "CWD: " << efs::current_path() << std::endl;
		demo_exists(full_path);
	}
	if (!get_exists(full_path))
	{
		std::cout << "File: " << full_path.c_str() << " not found" << std::endl;
	}
	std::ifstream fin(full_path);
	std::string line;

	std::getline(fin, line);

	std::vector<int> conditions = tokenize_to_int(line, ' ');
	// count of values in array
	int n = conditions[0];
	// number of left rotations
	int nlr = conditions[1];
	
	std::getline(fin, line);
	std::vector<int> array = tokenize_to_int(line, ' ');

	print_vector(array);

	bool r = lShiftVector(array, nlr);
	print_vector(array);
	return 0;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
