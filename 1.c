#include <stdio.h>
int main(){
int a[5], t, i, maxi, mini;
for(i=0; i<5; i++)
scanf("%d", &a[i]);
mini = maxi =   0   ;
for(i=1; i<5; i++){
if( a[mini]>a[i]     )mini = i;
if(a[i]>a[maxi])      maxi=i  ;
}
printf("最小:%3d\n", mini);
printf("最大:%3d\n", maxi);
t = a[maxi];
    a[maxi]=a[mini]            ;
a[mini] = t;
printf("调整后的数为: ");
for(i = 0; i < 5; i++)
printf("%d ", a[i]);
printf("\n");
return 0;
}