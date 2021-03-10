#include <stdio.h>
#include <math.h>
using namespace std;

float delta(int a,int b,int c);
int main()
{
	int a,b,c,d;
	float x1,x2;
	printf("Input a,b,c : ");
	scanf("%d %d %d",&a,&b,&c);
	d = delta(a,b,c);
	if (d < 0)
	{
		printf("No roots.");
	}
	else
	{
		if (d == 0)
		{
			x1 = -b/2*a;
			printf("x1 : %.2f",x1);
		}
		else
		{
			x1 = (-b + sqrt(d)) / 2*a;
			x2 = (-b - sqrt(d)) / 2*a;
			printf("x1 : %.2f \nx2 : %.2f",x1,x2);
		}
	}
	return 0;
}

float delta(int a,int b,int c)
{
	return pow(b,2) - 4*a*c;
}
