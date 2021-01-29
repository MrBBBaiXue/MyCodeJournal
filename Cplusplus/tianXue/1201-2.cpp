#include <stdio.h>
#define MAX 10000
using namespace std;

int main()
{
	char c[MAX];
	gets(c);
	int k = 0,a,e,i,o,u;
	a = e = i = o = u = 0;
	while (c[k] != '\0')
	{
		switch (c[k])
		{
			case 'A':
			case 'a':
				a++;
				break;
			case 'E':
			case 'e':
				e++;
				break;
			case 'I':
			case 'i':
				i++;
				break;
			case 'O':
			case 'o':
				o++;
				break;
			case 'U':
			case 'u':
				u++;
				break;
		}
		k++;
	}
	printf("%d %d %d %d %d",a,e,i,o,u);
	return 0;
}