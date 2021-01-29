#include <stdio.h>
struct SCORE {
	float Cprogram;
	float math;
	float english;
};
struct Student {
	char name[10]; // Student Name
	struct SCORE score;
	float total;
};
void ReadStudentInfo(struct Student stu[]);
void CalStudentScore(struct Student stu[]);
void OutputStudentInfo(struct Student stu[]);
void SortStudent(struct Student stu[]);
