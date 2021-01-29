#include<stdio.h>
#include<string.h>
#define MAX 10000
using namespace std;
int findLength(char array[]);

int main()
{
	char a[MAX],b[MAX],c[2*MAX];
	
	//Input Data
	printf("Array A : ");
	gets(a);
	printf("Array B : ");
	gets(b);
	
	//Find length (use function)
	int lenA = findLength(a);
	int lenB = findLength(b);
	
	//Operations
	int j = lenA - 1;
	int k = lenB - 1;
	int n = (lenA >= lenB) ? lenB : lenA;
	//reverse
	for (int i = 0; i <= 2*n - 1;i++)
	{
		if (i % 2 == 0)
		{
			c[i] = a[j];
			j--;
		}
		else
		{
			c[i] = b[k];
			k--;
		}
	}
	//apply delta
	j++;k++;int i = 0;
	while (j != 0 || k != 0)
	{
		if (j != 0)
		{
			c[2*n + i] = a[j - 1];
			j--;
		}
		else
		{
			c[2*n + i] = b[k - 1];
			k--;
		}
		i++;
	}
	//add '\0' to end
	c[2*n + i + 1] = '\0';
	
	//Output Data
	printf("Output : %s",c);
	
	return 0;
}

int findLength(char array[])
{
	int length = 0;
	while(array[length] != '\0')
	{
		length++;
	}
	return length;
}