#include <iostream>
#include <string>
#include <cstdio>
#include <ostream>
#include <fstream>
#include <algorithm>
#include <vector>
#include <functional>
#include <sstream>

#include <filesystem>
//namespace fs = std::filesystem;

#include <experimental/filesystem>
namespace efs = std::experimental::filesystem;
#include "parseUtil.h"

using namespace std;


std::string ltrim(const std::string &str) {
	string s(str);

	s.erase(
		s.begin(),
		find_if(s.begin(), s.end(), not1(ptr_fun<int, int>(isspace)))
	);

	return s;
}

std::string rtrim(const std::string &str) {
	string s(str);

	s.erase(
		find_if(s.rbegin(), s.rend(), not1(ptr_fun<int, int>(isspace))).base(),
		s.end()
	);

	return s;
}

std::vector<string> split(const std::string &str) {
	vector<string> tokens;

	string::size_type start = 0;
	string::size_type end = 0;

	while ((end = str.find(" ", start)) != string::npos) {
		tokens.push_back(str.substr(start, end - start));

		start = end + 1;
	}

	tokens.push_back(str.substr(start));

	return tokens;
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

void demo_exists(efs::path& p, efs::file_status s) {
	std::cout << p;
	bool bexist = efs::status_known(s) ? efs::exists(s) : efs::exists(p);

	if (Verbose()) {
		if (bexist) {
			std::cout << " Exists\n";
		}
		else {
			std::cout << " does not Exist\n";
		}
	}
}

bool read_array_lines(efs::path& p, std::vector<std::string>& result)
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

	for (auto const& val : v)
	{
		std::cout << val << std::endl;
	}
}

