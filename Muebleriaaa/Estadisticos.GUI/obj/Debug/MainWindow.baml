   M S B A M L   `   `   `  ����K  GEstadisticos.GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Estadisticos.GUIEstadisticos.GUI  5   	   !    Estadisticos.GUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Estadisticos.GUI     5   	   R NOxyPlot.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	     � Title$  Estadisticos��5	   	   $	��600��6   $
��1000��6+   ��5
      �� 5   
   .��5      �� ��5   
   �� 5       �� ImageSource$ /Imagenes/fondo1.jpg��6   .@�5   
   �� $��Estadisticos��6   $	��100��6(   .��5      �  � ColumnDefinitions 5      �� 5      $
��121* �6'   �� 5      $
��372* �6'    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��452* �6$   .+�5      � $��0��6   $��0��6,   $��2��69   $��15q�6N   ��5      �� 5       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5       �  � Color$ Black��6+    � Offset$ 0Q�69   � 5!      $ 1Q�6,   5"      .+�5$      ��  �� Orientation$ 
Horizontal=�6!   .+�5%      �� 
�������$��30��63   $��87��6?   $��14(�6J   $��5q�6X   .��6c   	Categoria6n   �� 5&      -   5        	 ��Name$	 CmbEstadisticosCategoria��5&   ;   $��25��6#   $	��220��6/   6_   5'      �� 5(      $ 
Horizontal=�6!   .+�5)      �� 
�������$��30��63   $��95��6?   $��14(�6J   $��5q�6X   .��6c   
Empleado6m   �� 5*      -   5        $	 cmbFechaEstadisticos��5*   ;   $��25��6#   $	��220��6/   6[   5+      �� 5,      -   5        
 ��Name$
 btnCalcularEstadisticos��5,   @   $��95��6   $��4q�6(   $��35��64   ���	#FF3A3333���	#FFFDFDFD.��5-      �� $ 
Horizontal=�6%   .+�5.      �� ���	#FFF5ECEC$
��Bold"�6;   $��14(�6M   .��6[   
Graficar6e   5/      50      �� 51      -   5        $
 btnReportes��51   @   $��95��6   $��4q�6(   $��35��64   ���	#FF3A3333���	#FFFDFDFD.��52      �� $ 
Horizontal=�6%   .+�53      �� ���	#FFF5ECEC$
��Bold"�6;   $��14(�6M   .��6[   
Reportes6e   54      55      56      &   System.Windows.Controls.DataGrid  57      -   5          Name$ dtgTablaEstadisticos��57   E   $��0��6   $��1��6,   $��20q�69   6e     OxyPlot.Wpf.PlotView  58      -   5          Name$ Grafica��58      $��1��60   $��1��6@   $��20q�6M   59      5:      �� 5;   
   -   5         ��Name$ btnSalir��5;      $��52��6Q   $��20��6]   $��13(�6j   .��6x   Salir6   5<      5=      