#include <stdio.h>
#include <string.h>
#include "StudentOperation.h"
#define N 3 //Student Number
#define M 2
int main() {
	struct Student	stu[N];
	ReadStudentInfo(stu);
	CalStudentScore(stu);
	OutputStudentInfo(stu);
	SortStudent(stu);
	printf("\n\nAfter Sorting...\n")	;
	//Output	Student Informatiion
	int i;
	for (i=0; i<N; i++) {
		printf("%-15s",stu[i].name);
		// for(j=0;j<M;j++)
		printf("%-8.2f%-8.2f%-8.2f",stu[i].score.Cprogram,stu[i].score.math,stu[i].score.english);
		printf("%-8.2f\n",stu[i].total);
	}
	return 0;
}
