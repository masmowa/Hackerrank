// LinkedListInsertAtHead.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
//#include <bits/stdc++.h>

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


#define MAS_TEST 1
#include "parseUtil.h"

using namespace std;

class SinglyLinkedListNode {
public:
	int data;
	SinglyLinkedListNode *next;

	SinglyLinkedListNode(int node_data) {
		this->data = node_data;
		this->next = nullptr;
	}
};

class SinglyLinkedList {
public:
	SinglyLinkedListNode *head;
	SinglyLinkedListNode *tail;

	SinglyLinkedList() {
		this->head = nullptr;
		this->tail = nullptr;
	}

};

void print_singly_linked_list(SinglyLinkedListNode* node, string sep, ostream& fout) {
	while (node) {
		cout << node->data;

		node = node->next;

		if (node) {
			cout << sep;
		}
	}
	cout << std::endl;
}

void free_singly_linked_list(SinglyLinkedListNode* node) {
	while (node) {
		SinglyLinkedListNode* temp = node;
		node = node->next;

		delete(temp);
	}
}

// Complete the insertNodeAtHead function below.

/*
 * For your reference:
 *
 * SinglyLinkedListNode {
 *     int data;
 *     SinglyLinkedListNode* next;
 * };
 *
 */
SinglyLinkedListNode* insertNodeAtHead(SinglyLinkedListNode* llist, int data) {
	SinglyLinkedListNode * newHead = new SinglyLinkedListNode(data);
	if (NULL == llist)
	{
		llist = newHead;
	}
	else {
		newHead->next = llist;
		llist = newHead;
	}
	return llist;
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


	int count = stoi(line.c_str());
	SinglyLinkedList* llist = new SinglyLinkedList();

	for (int i = 0; i < count; ++i)
	{
		std::getline(fin, line);
		int llist_item = stoi(line.c_str());

		SinglyLinkedListNode* llist_head = insertNodeAtHead(llist->head, llist_item);
		llist->head = llist_head;
	}

	print_singly_linked_list(llist->head, "\n", cout);
	cout << "\n";

	free_singly_linked_list(llist->head);


}

int main()
{
    std::cout << "Hello World!\n";

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
