   M S B A M L   `   `   `  ????F  BBookLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BookLibrary.ViewsBookLibrary.Views  5           BookLibrary.Views.ModifyUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:BookLibrary.Views     5      .??5	      ?    
babyPowder#??[  6     ? ColumnDefinitions  5
   
   ?? 5      $??3* ?6   6,   ?? 5      6!   .+?5   
   ?? .+?5      ?? $
??Left=?6   $	??Top=?64   .+?5      ?? ??6   ?? *BackCommand+.??5      ?? $??/Images/leftarrow.png??6   $??30??6<   6I   5      5      ?? 5      5      &   System.Windows.Controls.DataGrid  5      -   5        $??modifyDataGrid??5      ??6-   ?? *Books+ ?? SelectedItem 6K   ?? *SelectedBook+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?6?   5      ?? 5   
   $??1??6   $??Center=?6%   .+?5      ?? 
???? ??$??20(?6)   
???????$
??Bold"?5   (   $??5q?5      ??6    ?? *UpdateCommand+.??6B   Update ? 	Resources 5       ?? 
TargetType ?? Property ?? Value??%d   '??       ?? 5       " ??6   .?5!      ??  ?@??CornerRadius$ 10??69   6F   5"      5#      5$      ?? 5&      
??? ? ?$??20(?6(   
???????$
??Bold"?5'   (   $??5q?5(      ??6    ?? *InsertCommand+.??6B   Insert 5*      ??%d   '??       ?? 5+      " ??6   .?5,      ??  ?@??CornerRadius$ 10??69   6F   5-      5.      5/      ?? 51      
???  ??$??20(?6&   
???????$
??Bold"?52   (   $??5q?53      ??6    ?? *DeleteCommand+.??6B   Delete 55      ??%d   '??       ?? 56      " ??6   .?57      ??  ?@??CornerRadius$ 10??69   6F   58      59      5:      5;      5=      5>      