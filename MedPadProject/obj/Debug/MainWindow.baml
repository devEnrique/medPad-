   M S B A M L   `   `   `  ����H  DMedPadProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MedPadProjectMedPadProject  5   	       MedPadProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MedPadProject     5   	     � Title$  MedPad+��5   	   $	��650��6   $	��950��6&   .��5	      � -   5         �Name$ grid1��5	      
����  �.+�5
   
   >� $��40,100,40,10q�6   
�������.��5      � -   5        $ grid2��5      $��30,33,30,30q�6"   .+�5      �� .@�5      �� $��Doctor��6   $��22��6.   $	��Top=�6:    � ToolTip$ Select Correct Tab��6R   .��5      ��  �� TabStripPlacement$ Bottom=�6%   .@�5      �� $��Login��6&   .��5   "   �� .+�5   &   �� �� 5   &   
User Name:6<   �� 5   &   -   5         ��Name$ txtDotorLoginUserName��5   .   $	��200��6M   $
��Left=�6Y   6v   �� 5   &   �� 5   &   	Password:6;   G� 5   &   -   5         G�Name$ txtDoctorLoginPassword��5   2   $	��200��6R   $
��Left=�6^   6{   �� 5   &   �� 5   &   -   5         ��Name$ btnDoctorEnter��5   -   $��50��6E   $
��Left=�6P   .��6�   Enter6�   5   #   5      �� 5      $��Register��6&   $  Click Tab Here To Register��68   .��5   "   �� .+�5   &   �� �� 5   &   First Name:6=   �� 5    &   -   5        $ txtBoxDoctorFisrtName��5    .   $	��200��6M   $
��Left=�6Y   6v   �� 5!   &   �� 5"   &   
Last Name:6<   �� 5#   &   -   5        $ txtBoxDoctorLastName��5#   .   $	��200��6L   $
��Left=�6X   6u   �� 5$   &   �� 5%   &   Email:68   �� 5&   &   -   5        $ txtDoctorEmail��5&   .   $	��200��6F   $
��Left=�6R   6o   �� 5'   &   �� 5(   &   Phone Number:6?   �� 5)   &   -	   5        $ txtBoxDoctorPhoneNumber��5)   .   $	��200��6O   $
��Left=�6[   6x   �� 5*   &   �� 5+   &   Create Username:6B   �� 5,   &   -
   5        $ txtBoxDoctorUsername��5,   .   $	��200��6L   $
��Left=�6X   6u   �� 5-   &   �� 5.   &   Craete Password:6B   G� 5/   &   -   5        $ txtBoxDoctorPassword��5/   2   $	��200��6P   $
��Left=�6\   6y   �� 50   &   62   �� 51   &   Confirm Password6B   G� 52   &   -   5        $! txtBoxDoctorConfirmPassword��52   2   $	��200��6W   $
��Left=�6c   6�   �� 53   &   �� 54   &   -   5        $ btnDoctorRegister��54   -   $��50��6H   $
��Left=�6S   .��6�   
Register6�   55   #   57      58      5:      �� 5;      $��Staff��6   $ Select Correct Tab��6-   .��5<      �� $ Bottom=�6%   .@�5=      �� $��login��6&   .��5>   "   �� .+�5?   &   �� �� 5@   &   
User Name:6<   �� 5A   &   -   5        $ txtStaffLoginUserName��5A   .   $	��200��6M   $
��Left=�6Y   6v   �� 5B   &   �� 5C   &   	Password:6;   G� 5D   &   -   5        $ txtStaffLoginPassword��5D   2   $	��200��6Q   $
��Left=�6]   6z   �� 5E   &   �� 5F   &   -   5        $ btnStaffEnter��5F   -   $��50��6D   $
��Left=�6O   .��6�   Enter6�   5G   #   5I      �� 5J      $��Register��6&   .��5K   "   �� .+�5L   &   �� �� 5M   &   First Name:6=   �� 5N   &   -   5        $ txtBoxStaffFisrtName��5N   .   $	��200��6L   $
��Left=�6X   6u   �� 5O   &   �� 5P   &   
Last Name:6<   �� 5Q   &   -   5        $ txtBoxStaffLastName��5Q   .   $	��200��6K   $
��Left=�6W   6t   �� 5R   &   �� 5S   &   Email:68   �� 5T   &   -   5        $ txtBoxStaffEmail��5T   .   $	��200��6H   $
��Left=�6T   6q   �� 5U   &   �� 5V   &   Phone Number:6?   �� 5W   &   -   5        $ txtBoxStaffPhoneNumber��5W   .   $	��200��6N   $
��Left=�6Z   6w   �� 5X   &   �� 5Y   &   Create Username:6B   �� 5Z   &   -   5        $ txtBoxStaffUsername��5Z   .   $	��200��6K   $
��Left=�6W   6t   �� 5[   &   �� 5\   &   Craete Password:6B   G� 5]   &   -   5        $ txtBoxStaffPassword��5]   2   $	��200��6O   $
��Left=�6[   6x   �� 5^   &   62   �� 5_   &   Confirm Password6B   G� 5`   &   -   5        $  txtBoxStaffConfirmPassword��5`   2   $	��200��6V   $
��Left=�6b   6   �� 5a   &   �� 5b   &   -   5        $ btnStaffRegister��5b   -   $��50��6G   $
��Left=�6R   .��6�   
Register6�   5c   #   5e      5f      5h      �� 5i      $��Admin��6   .��5j      �� .+�5k      �� �� 5l      
User Name:64   �� 5m      -   5        $ txtAdminName��5m   &   $	��200��6<   $
��Left=�6H   6e   �� 5n      �� 5o      	Password:63   G� 5p      -   5        $ txtAdminPassword��5p   *   $	��200��6D   $
��Left=�6P   6m   �� 5q      �� 5r      -   5        $ btnLogInAdmin��5r   %   $��50��6<   $
��Left=�6G   .��6   Enter6�   5s      5v      5x      5z      5{      o� 5|   
   $��50��6   $��40, 70, 40,0q�6   $	��Top=�61   .@�5}      m� -   5         m�Name$ menuItemHome��5}      $��Log Off��6-   6>   5~      5�      5�      