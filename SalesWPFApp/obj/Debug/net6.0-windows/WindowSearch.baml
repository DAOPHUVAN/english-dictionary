   M S B A M L   `   `   `  ????F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5   	       SalesWPFApp.WindowSearch   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalesWPFApp     5   	     ? Title$  WindowSearch??5   	   $	??450??6   $	??800??6+   .??5	      ? .+?5
   
   ]? $	??Top=?6   $??10q?6,   .+?5      ?  ? RowDefinitions 5      ?? 5      $
??Auto ?6$   ?? 5      $??* ?6$   ?? 5      $??4* ?6$   ?? 5      $??* ?6$   .+?5      ?? 
????ح? ?? Orientation$ Vertical=?65   $
??Left=?5      $	??400??68   .+?5      ?? -   5        $??lbTitle??5      
???  ??$??DemiBold"?6<   $??20(?5      $??Search Information??6*   ?? 5      -   5        $??txtInfo??5      $??Stretch=?6-   $??25??5      ??5      ??  ?? Path$ 	ProductId? ?? Mode$ OneWay=? ? DataContext 5      ??  ?? ElementName$ 	lvMembers??$ SelectedItem??? 5      $??1??6!   $ 
Horizontal=?6.   $
??Left=?5      .+?5       ?? -   5         ??Name$ 	btnSearch??5    !   $??10q?64   $??80??6C   $??Search??6N   6_   5"      5#      ?? 5&      -   5        $??
lvProducts??5&   (   $??2??6   $
??Auto??6:   $
??Auto??6G    ?? View 5'      ?? 5(      .P?5)      ?? $??
Product ID??6-   	 ?? Width$		 100??6B   
 ?? DisplayMemberBinding
 5*   %   ?? $ 	ProductId??? 5+      $??Category Id??6-   $		 200??6B   
 5,   %   ?? $ 
CategoryId??? 5-      $??Product Name??6-   $		 200??6D   
 5.   %   ?? $ ProductName??? 5/      $??Weight??6-   $		 100??6=   
 50   %   ?? $ Weight??? 51      $??
Unit Price??6-   $		 100??6B   
 52   %   ?? $ 	UnitPrice??? 53      $??Unitsln Stock??6-   $		 200??6E   
 54   %   ?? $ UnitslnStock?55      57      58      59      5:      5;      