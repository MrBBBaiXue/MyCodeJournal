#include <stdio.h>
#include <string.h>
#define MAXN 10000
using namespace std;

int main()
{
	char str[MAXN], *p;
	printf("input String : ");
	gets(str);
	p = str;
	int i = 0;
	while (*p != '\0')
	{
		i++;
		p++;
	}
	printf("%d",i);
	return 0;
}