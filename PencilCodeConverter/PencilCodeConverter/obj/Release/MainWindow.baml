   M S B A M L   `   `   `  ���� N  JPencilCodeConverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PencilCodeConverterPencilCodeConverter  $    PencilCodeConverter.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:PencilCodeConverter       � Title$  PencilCode Converter��$��318.811��$	��601�� � WindowStartupLocation$ CenterScreen=� � Icon$ pencilcodeicon.ico��.��� 
����  �.+��� -    ��Name$ 
tabControl��$
��Left=�$	��Top=�$	��288��$	��592��
��� � �.@��� 
�������$��
PencilCode��$��20(�.��� $��Stretch=�
��� � �.+��� -    ��Name$ PencilCode_Button��
����  �
�������$��
PencilCode��$
��Bold"�$��25(�$
��Left=�$	��Top=�$	��161��$	��245���� -   $ CreateAccount_Button��
����  �
�������$��Create Account��$
��Bold"�$��20(�$��Center=�$	��Top=�$	��161��$	��245��$��210,0,211,0q��� -   $ EV3Doc_Button��
����  �
�������$��
EV3 Manual��$
��Bold"�$��25(�$��Right=�$	��Top=�$	��161��$	��110���� -   $ MSBDoc_Button��
����  �
�������$%��Microsoft Small
  Basic Manual��$
��Bold"�$��20(�$��Right=�$	��Top=�$	��161��$	��110��$��	0,135,0,0q��� 
�������$��Convert��$��20(�.��� $��Stretch=�
��� � � � ColumnDefinitions �� $	��65* ��� $
��226* �.+��� -    ��Name$ PencilCode_URL��$��Center=�$��59�� �� TextAlignment$ Center=�$��20(�
������� �� TextWrapping$
 Wrap=�$	��Top=�$	��562��$��
10,10,10,0q�$��2���� -   	 ��Name$	 New_URL_TextBlock��
��� � �$��Center=�$��
48,74,47,0q�$
��Wrap=�$	��Top=�$	��487��
 �� TextAlignment$
 Center=�$��2���� -   $ Enter_Button��$��ENTER��$
��Bold"�$��45(�
����  �
�������$��Center=�$	��Top=�$	��162��$	��139��$��10,96,410,0q�$��2���� -	   $ Download_Button��$��DOWNLOAD��$
��Bold"�$��25(�
����� �
�������$��Center=�$	��Top=�$	��162��$	��139��$��280,96,10,0q�$��1��{�.  �� 
�������$��Microsoft Small Basic��$��20(�.��� .+��� -
   $ 	SB_Button��$��Small Basic��$
��Bold"�$��25(�
����  �
�������$	��200��$	��200��