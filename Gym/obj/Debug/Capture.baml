   M S B A M L   `   `   `  ����>  :Gym, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GymGym  5   	   H DWebcamControl, Version=3.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:WebcamControl;assembly=WebcamControlWebcamControl 5   	       Gym.Capture   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Gym     5   	   LWebcamControl2clr-namespace:WebcamControl;assembly=WebcamControl     5   	   -   5          � Title$  Capture��5	   	   $��453.192��6   $��453.192��6*    � WindowStartupLocation$ CenterScreen=�6:    � 
ResizeMode$ NoResize=�6_    � 	Resources 5
         DevicesListTemplate��%I   &	        �� 5   
   .R�5      �� ��6   �� *Name+5      5      .��5      � .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69   $	��341��6T   $��	44,21,0,0q�6a   $	��Top=�6t   $	��361��6�   ._�5      �� -   5         ��Name$ videoPlayer��5      $��UniformToFill=�6)   $��1��6A   $��9,0,9,9q�6R   5      �� 5   
   -   5         ��Name$ comboBox��5      $	��167��5   
   $��21��5   
   $��	47,0,0,10q�5   
   $
��Left=�5   
   $��Bottom=�5   
    �� DisplayMemberPath$
 Name��5   
   ��5   
   �� *VideoDevices+ �� SelectedItem 5   
   �� *CurrentDevice+�� 5   
   $	��167��6   $��24��5   
   $��	47,0,0,31q�5   
   $
��Left=�5   
   $��Bottom=�5    
   $��Select video source��5!   
   �� 5"   
   -   5        $��67��5"      $��21��5#   
   $��
250,0,0,10q�5$   
   $
��Left=�5%   
   $��Bottom=�5&   
   $��Start��5(   
   �� 5)   
   -   5         ��Name$ 
btnCapture��5)      $��67��6%   $��21��5*   
   $��
333,0,0,10q�5+   
   $
��Left=�5,   
   $��Bottom=�5-   
   $��Capture��5.   
   6   �� 5/   
   -   5        $ imgShow��5/      $
��Left=�6!   $��79��6<   $
��Fill=�6H   $��
47,283,0,0q�6X   $	��Top=�6l   $��79��6�   51      52      