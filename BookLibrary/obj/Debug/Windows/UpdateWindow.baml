   M S B A M L   `   `   `  ????F  BBookLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BookLibrary.WindowsBookLibrary.Windows  5   	   &     BookLibrary.Windows.UpdateWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:BookLibrary.Windows     5   	     ? Title$  UpdateWindow??5   	   $	??295??6   $	??350??6+   .??5	      ? 
???????.+?5
   
   ?? $??Center=?6   .+?5      ?? .+?5      ?? $??Black"?6   $??Center=?6+   
???  ??.??6`   Data Update Forum6s   5      ?? 5      
??????? ?? Orientation$ 
Horizontal=?5      .+?5      ?? $??Right=?6   $??67??6;   $??18(?6F   
???????.??6g   ID:6l   ?? 5      $??0,5,0,0q?6h   
???????$??
ExtraBlack"?5   .   $??18(?6F   ??5      ?? *	Book.Id+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?5   V   5      ?? 5      
???????$ 
Horizontal=?5      .+?5      ?? $??0,5,0,0q?6   .??6)   	Book Name64   ?? 5      $	??200??5      $??
5,10,10,10q?6'   ??5      ?? *	Book.Name+$ TwoWay=?$ PropertyChanged=?5   =   5      ?? 5      
???????$ 
Horizontal=?5      .+?5      ?? $??0,5,0,0q?6   .??6)   
Page Count65   ?? 5      $	??200??5       $??
6,10,10,10q?6'   ??5      ?? *
Book.Pages+$ TwoWay=?$ PropertyChanged=?5    =   5!      ?? 5#      
???????$ 
Horizontal=?5$      .+?5%      ?? $??0,5,0,0q?6   .??6)   
Year Press65   ?? 5&      $	??200??5'      $??14,10,10,10q?6'   ??5&      ?? *Book.YearPress+$ TwoWay=?$ PropertyChanged=?5'   >   5(      ?? 5)      
???????$ 
Horizontal=?5*      .+?5+      ?? $??0,5,0,0q?6   .??6)   
Quantity63   ?? 5,      $	??200??5-      $??21,10,10,10q?6'   ??5,      ?? *Book.Quantity+$ TwoWay=?$ PropertyChanged=?5-   >   5.      ?? 50      
???????$ 
Horizontal=?51      .+?52      ?? $??0,5,0,0q?6   .??6)   	Comment62   ?? 53      $	??200??54      $??14,10,10,10q?6'   ??53      ?? *Book.Comment+$ TwoWay=?$ PropertyChanged=?54   >   55      56      58      59      