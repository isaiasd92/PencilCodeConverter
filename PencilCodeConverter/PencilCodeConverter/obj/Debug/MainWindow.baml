   M S B A M L   `   `   `  ����N  JPencilCodeConverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PencilCodeConverterPencilCodeConverter  5   	   $    PencilCodeConverter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PencilCodeConverter     5   	     � Title$  PencilCode Converter��5   	   $��318.811��6&   $	��601��67    � WindowStartupLocation$ CenterScreen=�6C   .��5	      � 
����  �.+�5
   
   �� -   5         ��Name$ 
tabControl��5
      $
��Left=�6)   $	��Top=�6D   $	��288��6\   $	��592��6i   
��� � �.@�5      �� 
�������$��
PencilCode��6(   $��20(�6<   .��5      � $��Stretch=�6   
��� � �.+�5      �� -   5         ��Name$ PencilCode_Button��5      
����  �
�������$��
PencilCode��6a   $
��Bold"�6v   $��25(�6�   $
��Left=�6�   $	��Top=�6�   $	��161��6�   $	��245��6�   6�   �� 5      -   5        $ CreateAccount_Button��5      
����  �
�������$��Create Account��6d   $
��Bold"�6}   $��20(�6�   $��Center=�6�   $	��Top=�6�   $	��161��6�   $	��245��6�   $��210,0,211,0q�6�   �� 5      -   5        $ EV3Doc_Button��5      
����  �
�������$��
EV3 Manual��6]   $
��Bold"�6r   $��25(�6�   $��Right=�6�   $	��Top=�6�   $	��161��6�   $	��110��6�   6�   �� 5      -   5        $ MSBDoc_Button��5      
����  �
�������$%��Microsoft Small
  Basic Manual��6]   $
��Bold"�6�   $��20(�6�   $��Right=�6�   $	��Top=�6�   $	��161��6�   $	��110��6�   $��	0,135,0,0q�6�   6  5      5      �� 5      
�������$��Convert��6(   $��20(�69   .��5      � $��Stretch=�6   
��� � � � ColumnDefinitions 5      �� 5      $	��65* �6+   �� 5      $
��226* �6+   .+�5      �� -   5         ��Name$ PencilCode_URL��5      $��Center=�66   $��59��6S    �� TextAlignment$ Center=�6_   $��20(�6v   
������� �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��562��6�   $��
10,10,10,0q�6�   $��2��6  �� 5      -   5         ��Name$ New_URL_TextBlock��5       
��� � �$��Center=�6N   $��
48,74,47,0q�6k   $
��Wrap=�6   $	��Top=�6�   $	��487��6�   	 �� TextAlignment$	 Center=�6�   $��2��6�   �� 5      -   5        $ Enter_Button��5      $��ENTER��63   $
��Bold"�6C   $��45(�6U   
����  �
�������$��Center=�6�   $	��Top=�6�   $	��162��6�   $	��139��6�   $��10,96,410,0q�6�   $��2��6
  �� 5      -	   5        $ Download_Button��5      $��DOWNLOAD��66   $
��Bold"�6I   $��25(�6[   
����� �
�������$��Center=�6�   $	��Top=�6�   $	��162��6�   $	��139��6�   $��280,96,10,0q�6�   $��1��6  {�.  6  5      5      �� 5      
�������$��Microsoft Small Basic��6(   $��20(�6G   .��5       � .+�5!      �� -
   5        $ 	SB_Button��5!      $��Small Basic��60   $
��Bold"�6F   $��25(�6X   
����  �
�������$	��200��6�   $	��200��6�   6�   5"      5#      5$      5%      5&      