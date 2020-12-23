#include <stdio.h>
#include <string.h>
#include "StudentOperation.h"
#define N 3 //Student Number
#define M 2
void ReadStudentInfo(struct Student stu[]) {
	int i,j;
	float t;
	//Read Student Info
	for (i=0; i<N; i++) {
		scanf("%s",stu[i].name);
		// for(j=0;j<M	;j++)
		scanf("%f",&stu[i].score.Cprogram);
		scanf("%f",&stu[i].score.math);
		scanf("%f",&stu[i].score.english);
	}
}
void CalStudentScore(struct Student stu[]) {
	//Student Total Score Calculation
	int i,j;
	for(i=0; i<N; i++) {
		stu[i].total=0;
		for(j=0; j<M; j++)
			//  stu [i].total+= stu[i].score[j];
			stu [i].total=stu[i].score.Cprogram+stu[i].score.math+stu[i].score.english;
	}
}
void OutputStudentInfo(struct Student stu[]) {
	int i,j;
	for (i=0; i<N; i++) {
		printf("%-15s",stu[i].name);
		// for(j=0;j<M;j++)
		printf("%-8.2f%-8.2f%-8.2f",stu[i].score.Cprogram,stu[i].score.math,stu[i].score.english);
		printf("%-8.2f\n",stu[i].total);
	}
}
void SortStudent(struct Student stu[]) {
	int i,j;
	for (i=0; i<N; i++) {
		int temp=i;
		for(j=i+1; j<N; j++)
			if (stu[j]. total >stu[temp]. total)
				temp=j;
		if (temp!=i) {
			float tScore;
			char tname[20];
			//change name
			strcpy(tname,stu[i].name);
			strcpy(stu[i].name,stu[temp].name);
			strcpy(stu[temp].name,tname);
			//change score
			// for(int k=0;k<M;k++)
			//{
			tScore=stu[i].score.Cprogram;
			stu[i].score.Cprogram=stu[temp].score.Cprogram;
			stu[temp].score.Cprogram=tScore;
			tScore=stu[i].score.math;
			stu[i].score.math=stu[temp].score.math;
			stu[temp].score.math=tScore;
			tScore=stu[i].score.english;
			stu[i].score.english=stu[temp].score.english;
			stu[temp].score.english=tScore;
			//}
			//change total
			tScore=stu[i].total;
			stu[i].total=stu[temp].total;
			stu[temp].total=tScore;

		}
	}
}
