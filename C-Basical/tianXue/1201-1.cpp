#include <stdio.h>

using namespace std;

int main()
{
	int a[10];
	printf("Input 10 integers :");
	for (int i = 0;i <= 9;i++)
	{
		scanf("%d",&a[i]);
	}
	//准备待排序的数组sortA,sortB
	int sortA[10],sortB[10];
	for (int i = 0;i <= 9;i++)
	{
		sortA[i] = a[i];
		sortB[i] = a[i];
	}
	
	//选择排序
	for (int i = 0; i <= 9;i++)
	{
		for (int j = i+1;j <= 9;j++)
		{
			if (sortA[i] < sortA[j])
			{
				int temp;
				temp = sortA[i];
				sortA[i] = sortA[j];
				sortA[j] = temp;
			}
		}
	}
	
	//冒泡排序
	for (int i = 0; i < 9; i++)
	{
		for (int j = 0; j < 9 - i; j++)
		{
			if (sortB[j] < sortB[j + 1])
			{
                int temp = sortB[j];
                sortB[j] = sortB[j + 1];
                sortB[j + 1] = temp;
            }
		}
	}      
            
	//输出sortA,sortB
	printf("SortA : ");
	for (int i = 0;i <= 9;i++)
	{
		printf("%d ",sortA[i]);
	}	
	printf("\n");
	printf("SortB : ");
	for (int i = 0;i <= 9;i++)
	{
		printf("%d ",sortB[i]);
	}	
	return 0;
}