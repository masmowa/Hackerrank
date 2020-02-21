// ConsoleApplication1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
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
#include <experimental/filesystem>

using namespace std;

#define MAS_TEST 1
#include <parseUtil.h>

int scoreTest(int Thold, vector<int> const & scores)
{
	int countProblems = 0;
	bool done = false;
	int offset = 1;
	int base = scores[0];
	int slast = scores.size() - 1;
	done = scores[slast] - base;
	if (done) {
		offset = 2;
	}
	done = false;
	for (int i = 0; i < scores.size(); i += offset)
	{
		countProblems++;
		if ((scores[i] - base) >= Thold)
		{
			done = true;
			break;
		}
	}

	return countProblems;
}

void ProcessInput(std::string const & input)
{
	efs::path inpath(input.c_str());
	if (Verbose())
	{
		std::cout << input << std::endl;
		//std::cout << "CWD: " << efs::current_path() << std::endl;
		demo_exists(inpath);
	}
	if (!get_exists(inpath))
	{
		std::cout << "File: " << input.c_str() << " not found" << std::endl;
	}
	std::ifstream fin(inpath);
	std::string line;
	std::getline(fin, line);
	int threshold = std::atoi(line.c_str());
	int input_count = 0;
	std::getline(fin, line);
	input_count = stoi(line.c_str());
	vector<int> test_scores;
	for (int i = 0; i < input_count; ++i)
	{
		std::getline(fin, line);
		int score = stoi(line.c_str());
		test_scores.push_back(score);
	}

	int problems_to_attempt = scoreTest(threshold, test_scores);

	cout << problems_to_attempt << std::endl;
}
int main()
{
	for (auto& p : efs::directory_iterator("input"))
	{
		string ps = p.path().string();
		ProcessInput(ps);
	}
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
