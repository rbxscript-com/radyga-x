   M S B A M L   `   `   `  ���� A  =Radyga, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RadygaRadyga      Radyga.MainWindow   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ^ ZICSharpCode.AvalonEdit, Version=6.1.1.20, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonedit.http://icsharpcode.net/sharpdevelop/avalonedit   localclr-namespace:Radyga  -     � Title$  Radyga�� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency . $	��396��$	��767��$��0q� � WindowStyle$
 None=� � Topmost .  � 
ResizeMode$ NoResize=���Z� .����  �� CornerRadius$ 7�� �� Padding$ 4q�$��0q�����  �� EndPoint$ 0.5,1&�	 �� 
StartPoint$	 0.5,0&�.��� 
 � Color$
 	#FF191919�� � Offset$ 1Q�� $
 	#FF131313��� $
 	#FF212121��$ 0.314Q����� $ 0.5,1&�$	 0.5,0&�.��� $
 Black��$ 0Q�� $
 	#FF191919��$ 1Q�._�� ���	#FF191919 � ColumnDefinitions �� $��0* ��� .+��� $ 
7, 7, 0, 0��$ 2q�$
��Left=�$��38��$	��Top=�$	��761��$��2�����	#FF212121$��	2,-4,-4,0q�._��� ���	#FF212121�� -    ��Name$ 
welcomeLbl��$y�Hidden=�$��	Welcome, ��$
��Left=�$��
-381,0,0,0q�$	��Top=�$��Segoe UI Semilight)�$��18(�$��1��$��32��$	��368���� $
��Left=�$��34��$	��Top=�$	��163�����	#FF131313$��2���� $	 100��$��1q�$
��Left=�$��58��$	��Top=�$��58�����	#FF131313$��
-8,-10,0,0q�$��2���� $
��Left=�$��39��$	��Top=�$��40��$��radygaFixed.png��$��1,0,0,0q�$��2��$
��Fill=��� $��Radyga��$
��Left=�$��51,0,0,0q�$	��Top=����	#FFED3B3B$��34��$��81��$��18(�$��1���� $��2��$
��Left=�$��27��$��	721,3,0,0q�$	��Top=�$��27��$ ��round_close_white_24dp.png���� $��2��$
��Left=�$��27��$��	678,0,0,0q�$	��Top=�$��27��$#��round_minimize_white_24dp.png���� $
��Left=�$��4��$��	36,-4,0,0q�$	��Top=�$	��119�����	#FF131313 J� RenderTransformOrigin$ 0.5,0.5&�$��1��z�V� .~��� ��  �� AngleX$ -0.092Q���  �� Angle$	 180Q�T�  T� X$
 0.05Q� T� Y$ 0.035Q��� $
��Left=�$��10��$��
118,11,0,0q�$	��Top=�$��53�����	#FF111111$ 0.5,0.5&�$��1��z�V� .~��� �� $ -0.092Q��� $ 125.27Q�T� $
 0.05Q�$ 0.035Q��� $
��Left=�$��24��$��
133,10,0,0q�$	��Top=�$��48�����	#FF212121$ 0.5,0.5&�$��1��z�V� .~��� �� $ -0.092Q��� $ 125.27Q�T� $
 0.05Q�$ 0.035Q��� $
��Left=�$��17��$��
123,34,0,0q�$	��Top=�$��45�����	#FF191919$��1���� $
��Left=�$��22��$��-332,91,0,0q�$	��Top=�$	��174�����	#FF191919�� $!��UI сделал QufStudios
��$
��Left=�$��-336,91,0,0q�$	��Top=�$��25��$	��254�����	#FF232323���	#DD009500�� $ 5��$
��Left=�$��61��$��	6,325,0,0q�$	��Top=�$	��560�����	#FF131313$��1���� $ 5��$
��Left=�$	��334��$��
577,52,0,0q�$	��Top=�$	��176�����	#FF131313$ 0.5,0.5&�$��1��._��� -    ��Name$ 
scriptbox1���� $ 5��$ 3q�$
��Left=�$	��228��$��6,52,0,0q�$	��Top=�$	��560�����	#FF131313$��1��._�'  !ICSharpCode.AvalonEdit.TextEditor  ?
avalonEdit.http://icsharpcode.net/sharpdevelop/avalonedit  -     Name$ 
TextEditor�� J� Opacity$	 100Q�$��consolas)�$
��12px(�$��0,0,0,0q����	#FF131313   SyntaxHighlightingM  GICSharpCode.AvalonEdit.Highlighting.HighlightingDefinitionTypeConverter$	 LUA 
�������"   VerticalScrollBarVisibility$
 Auto=�$   HorizontalScrollBarVisibility$
 Auto=�$��3q�   LineNumbersForeground �	#FFED3B34   ShowLineNumbers . $��0q�1  +MaterialDesignThemes.Wpf.ScrollViewerAssist    CornerRectangleVisibility$ Hidden=��� -    ��Name$ execBtn��+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�$��Execute��$
��Left=�$��	6,285,0,0q�$	��Top=�$	��197�����	#FF131313
�������$��36��$��1����Z� �� -   $ 
opnfileBtn��$ Depth0=�$��	Open File��$
��Left=�$��329,285,0,0q�$	��Top=�$	��116�����	#FF131313
�������$��36��$��1����Z� �� -   $ savefileBtn��$ Depth0=�$��	Save File��$
��Left=�$��450,285,0,0q�$	��Top=�$	��116�����	#FF131313
�������$��36��$��1����Z� �� $
��Left=�$��95��$��-336,-4,0,0q�$	��Top=�$	��280��$��QUFTeamLogoSmallwhite.png���� $��2��$
��Left=�$��36��$��
21,338,0,0q�$	��Top=�$��40��$(��"round_auto_fix_high_white_24dp.png���� -   $ inject�� � ToolTip$ Inject��$	 100Q�$ Depth0=�$
��Left=�$��
18,332,0,0q�$	��Top=�$��45��$��45��$��Segoe UI Light)�$��16(�$��1����Z� ��Z� ��Z� �� $��2��$
��Left=�$��36��$��
68,338,0,0q�$	��Top=�$��40��$%��round_people_alt_white_24dp.png���� -	   $ credits��$ Credits��$	 100Q�$ Depth0=�$
��Left=�$��
64,332,0,0q�$	��Top=�$��45��$��45��$��Segoe UI Light)�$��16(�$��1����Z� ��Z� ��Z� �� -
    ��Name$ dllCombo��$��2��$
��Left=�$��232,345,0,0q�$	��Top=�$	��314��
�������  �� SelectedIndex$  0��.@��� $��EasyExploits DLL���� $��WeAreDevs DLL���� $��KRNL DLL���� $��Electron DLL���� $��2��$
��DLL:��$
��Left=�$��186,340,0,0q�$	��Top=�$��18(�$��Segoe UI Semilight)�
��������� -   $ clearBtn��$ Depth0=�$��Clear��$
��Left=�$��208,285,0,0q�$	��Top=�$	��116�����	#FF131313
�������$��36��$��1����Z� �� $��2��$
��Left=�$��36��$��119,338,0,0q�$	��Top=�$��40��$#��round_settings_white_24dp.png���� -   $ settings��$ Settings��$	 100Q�$ Depth0=�$
��Left=�$��114,332,0,0q�$	��Top=�$��45��$��45��$��Segoe UI Light)�$��16(�$��1����Z� ��Z� ��Z� �� -   ! ��Name$! 	dragPanel��$��2��$
��Left=�$��34��$	��Top=�$	��759�����	#02000000�� -   $ exitBtn��$	 100Q�$ Depth0=�$��X��$��713,0,3,358q�$��Bottom=�$��27��$��Segoe UI Light)�$��16(�$��1����Z� ��Z� ��Z� �� -   $ minBtn��$	 100Q�$ Depth0=�$��_��$
��Left=�$��	670,3,0,0q�$	��Top=�$��43��$��27��$��Segoe UI Light)�$��16(�$��1����Z� ��Z� ��Z� 