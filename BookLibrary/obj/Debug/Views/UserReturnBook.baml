   M S B A M L   `   `   `  ????F  BBookLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:BookLibrary.ViewsBookLibrary.Views  5      &     BookLibrary.Views.UserReturnBook   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:BookLibrary.Views     5      .??5	      ?    
babyPowder#??[  6   .+?5
   
   ?? $
??Left=?6   .+?5      ?? ??6   ?? *BackCommand+.??5      ?? $??/Images/leftarrow.png??6   $??30??68   6E   5      5      ?? 5   
   $
??Left=?6   $??Bottom=?60   .+?5      ?? $
??Bold"?6   $??55(?6'   
??? ? ?$??Kunstler Script)?6I   .??6f   	Library6o   5      ?? 5   
   $??15q?6   $	??Top=?6!   .+?5      ?? $	??450??6   $??2q?6!    
 coffee#??[ 65   ._?5      ??   yellowGreen#??[ 6   $
??Bold"?6B   $??50(?6T   $??Center=?6b   .??6?   Return Book6?   5      5      ?? 5   
   $??Center=?6     ?? Orientation$  Vertical=?60   $??Center=?6G   .+?5      ?? $  
Horizontal=?6   .+?5      ?? $??5q?6   $??30(?6#   $??Times New Roman)?61   .??6N   	Book Id6W   ?? 5      -   5        $??
bookIdTxtb??5      $??60,5,5,5q?6E   $??30(?6W   $	??200??6e   ??6-   ?? *BookId+6s   ?? 5      -   5        $??	bookIdLbl??5      
???  ??$??Center=?6:   $y?Hidden=?6\   .??6p   Wrong Input6}   5      ?? 5      $  
Horizontal=?6   .+?5       ?? $??5q?6   $??30(?6#   $??Times New Roman)?61   .??6O   
Student ID6[   ?? 5!      -   5        $??dayTxtb??5!      $??27,5,5,5q?6E   $??30(?6W   $	??200??6e   ??6*   ?? *	StudentId+6s   ?? 5"      -   5        $??dayLbl??5"      
???  ??$??Center=?67   $y?Hidden=?6Y   .??6m   Wrong Input6z   5#      ?? 5%      $  
Horizontal=?6   .+?5&      ?? $??5q?6   $??30(?6#   $??Times New Roman)?61   .??6O   Return Code6\   ?? 5'      -   5        $??	stdIdTxtb??5'      $??5q?6H   $??30(?6S   $	??200??6a   ??6,   ?? *
ReturnCode+6o   ?? 5(      -   5        $??stdIdLbl??5(      
???  ??$??Center=?69   $y?Hidden=?6[   .??6o   Wrong Input6|   5)      5-      ?? 5/   
   $??Bottom=?6   $??Center=?60   .+?50      ?? 
??? E??#??[  6N   $
??Bold"?51      $??10q?6&   $??0,0,0,45q?63   $??30(?6E   ??50      ?? *ReturnCommand+.??51   S   Return Book ? 	Resources 52       ?? 
TargetType ?? Property ?? Value??%h   '??       ?? 53      " ??6   .?54      ??  ?@??CornerRadius$ 10??69   56      57      58      59      5:      5;      5<      