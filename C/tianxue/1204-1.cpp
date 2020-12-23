#include<stdio.h>
#include<string.h>
#include<iostream>
#define MAXN 1000
using namespace std;
int main()
{
	char name[MAXN][MAXN];
	int score[MAXN];
	int i = 0; 
	printf("Input Data : \nIf the score is -1,the input ends.\n\n");
	while (true)
	{
		printf("Input Name of No.%d : ",i);
		scanf("\n");
		gets(name[i]);
		printf("Input Score of No.%d : ",i);
		scanf("%d",&score[i]);
		
		if(score[i] == -1)
		{
			name[i][0] = '@';
			score[i] = 0;
			break;
		}
		else
		{
			i++;
		}
	}
	printf("( total : %d ) - Find : ",i);
	char target[MAXN];
	getchar();
	gets(target);
	for (int j = 0;j <= i;j++)
	{
		if (strcmp(name[j],target) == 0)
		{
			printf("%s %d",name[j],score[j]);
		}
	}
	
	return 0;
}