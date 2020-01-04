// 2dArray-DS.cpp : This file contains the 'main' function. Program execution begins and ends there.
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
namespace fs = std::filesystem;

using namespace std;
#define MAS_TEST 1

inline bool Verbose() {
#if defined(MAS_TEST)
	return true;
#else
	return false;
#endif
}

// sum 3x3 hour-glass with (ro+1,co+0)=0,(ro+1,co+2)=0

void print_HG_Matrix(vector<vector<int>> arr, size_t rowOffset, size_t colOffset, size_t length) {
	if (Verbose()) {
		cout << std::endl;
		for (size_t row = rowOffset; row < rowOffset + length; ++row) {
			for (size_t col = colOffset; col < (colOffset + length); ++col) {
				cout << arr[row][col];
				if (col <= ((colOffset + length) - 1)) {
					std::cout << " ";
				}
			}
			cout << std::endl;
		}
	}
}

int hgSum(vector<vector<int>> arr, size_t rowOffset, size_t colOffset, size_t length) {
	int hgSum = 0;
	if (Verbose() && false)
	{
		cout << "rowOffset + length " << (rowOffset + length) << std::endl;
		cout << "colOffset + length " << (colOffset + length) << std::endl;
	}
	if (Verbose())
	{
		print_HG_Matrix(arr, rowOffset, colOffset, length);
	}
	if (((rowOffset + length) > arr[0].size()) || ((colOffset + length) > arr[0].size()) ) {
		return hgSum;
	}
	for (size_t rowIndex = rowOffset; rowIndex < (rowOffset + 3); ++rowIndex)
	{
		for (size_t colIndex = colOffset; colIndex < (colOffset + 3); ++colIndex)
		{
			// skip r,c (1, 0) or (1,2) skip
			if ((rowIndex - rowOffset) == 1) {
				if ((0 == (colOffset - colIndex)) || (colIndex - colOffset) == 2)
					continue;
			}

			if (Verbose() && false) {
				std::cout << "r: " << rowIndex << " c: " << colIndex << " s: " << hgSum << std::endl;
			}
			hgSum += arr[rowIndex][colIndex];
		}
	}

	return hgSum;
}
int hourglassSum(vector<vector<int>> arr) {
	int maxHGSum = (-9 * 7);
	size_t rowOffset = 0;
	size_t colOffset = 0;
	int sumCount = 0;
	int sum = 0;

	size_t offsetMax = arr[0].size() - 3;

	for (; rowOffset <= offsetMax; ++rowOffset)
	{
		for (colOffset = 0; colOffset <= offsetMax; ++colOffset)
		{
			sum = hgSum(arr, rowOffset, colOffset, 3);
			++sumCount;
			if (Verbose()) {
				cout << "sum-count = " << sumCount << " ";
				cout << " sum: " << sum << std::endl;
			}

			if (sum > maxHGSum)
			{
				maxHGSum = sum;
			}
		}
	}

	return maxHGSum;
}

vector<string> tokenize(std::string const &line, char delim)
{
	std::string token;
	vector<string> out;

	std::istringstream stm(line);

	while (std::getline(stm, token, delim))
	{
		out.push_back(token);
	}
	return out;
}

std::vector<int> tokenize_to_int(std::string const &line, char delim)
{
	std::vector<int> out;
	
	std::istringstream stm(line);
	std::string token;

	while (std::getline(stm, token, delim))
	{
		out.push_back(std::atoi(token.c_str()));
	}
	return out;
}

void demo_exists(fs::path& p, fs::file_status s = fs::file_status{}) {
	std::cout << p;
	bool bexist = fs::status_known(s) ? fs::exists(s) : fs::exists(p);

	if (Verbose()) {
		if (bexist) {
			std::cout << " Exists\n";
		}
		else {
			std::cout << " does not Exist\n";
		}
	}
}

bool read_array_lines(fs::path& p, std::vector<std::string>& result )
{
	bool res = true;
	std::ifstream in(p);
	if (!in) {
		std::cerr << "Cannot open the File : " << p << std::endl;
		return false;
	}
	std::string line;
	while (std::getline(in, line))
	{
		if (line.size() > 0)
		{
			result.push_back(line);
		}
	}
	in.close();

	return res;
}

void print_lines(std::vector<string> &v) {

	for (auto const& val: v)
	{
		std::cout << val << std::endl;
	}
}

template <class T>
void print_vector(std::vector<T> vec)
{
	if (Verbose()) {
		for (size_t i = 0; i < vec.size(); ++i)
		{
			std::cout << vec[i];
			if (i <= (vec.size() - 1)) {
				std::cout << " ";
			}
		}
		std::cout << std::endl;
	}
}

int main()
{
	fs::path base ("D:/Users/Mark/Documents/GitHub/Hackerrank/practice/2dArray-DS/2dArray-DS/input");
	fs::path inputFileName ("input00.txt");
	fs::path full_path = base / inputFileName;
	std::cout << full_path << std::endl;
	vector<vector<int>> arr(6);
	std::vector<std::string> vecOfStr;
	std::vector<std::string> tres;

    std::cout << "Hello World!\n";
	std::cout << "\n";
	demo_exists(full_path);
	if (!read_array_lines(full_path, vecOfStr))
	{
		std::cerr << "error reading " << full_path << std::endl;
	}
	else {
		// split lines of strings into vector, then convert to int
		if (Verbose()) {
			print_lines(vecOfStr);
		}
		for (int i = 0; i < 6; ++i)
		{
			cout << i << " : ";
#if 0
			tres = tokenize(vecOfStr[i], ' ');
			print_vector<string>(tres);
			//arr[i].resize(6);
#endif
			arr[i] = tokenize_to_int(vecOfStr[i], ' ');
			print_vector<int>(arr[i]);
		}
	}
	int result = hourglassSum(arr);
	if (Verbose())
	{
		cout << "hourglassSum = " << result << std::endl;
	}
	return result;
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
#if 0
int main()
{
	ofstream fout(getenv("OUTPUT_PATH"));

	vector<vector<int>> arr(6);
	for (int i = 0; i < 6; i++) {
		arr[i].resize(6);

		for (int j = 0; j < 6; j++) {
			cin >> arr[i][j];
		}

		cin.ignore(numeric_limits<streamsize>::max(), '\n');
	}

	int result = hourglassSum(arr);

	fout << result << "\n";

	fout.close();

	return 0;
}
#endif
