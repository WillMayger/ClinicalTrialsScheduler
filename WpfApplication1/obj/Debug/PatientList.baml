   M S B A M L   `   `   `  ����I  ENHSApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NHSApplicationNHSApplication  5   	        NHSApplication.PatientList   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:NHSApplication     5   	     � Title$  Clinical Trials Scheduler��5   	   $	��550��6+   $	��725��68   $	��750��6D   $	��550��6S   $	��750��6c   $	��550��6r   ���	#FFB9F9B9.��5	      � .+�5
   
   �� -   5         ��Name$ clinicalTrialsScheduler��5
      $��210,10,222,0q�65   $
��Wrap=�6K   $��Clinical Trials Scheduler��6_   $	��Top=�6�   $��26.667(�6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $��
10,184,0,0q�6@   $	��Top=�6T   $	��325��6l   $	��710��6y   ���	#FFB891F06�   �� 5   
   -   5         ��Name$ textBoxPatientFirstName��5      $
��Left=�63   $��22��6N   $��
245,84,0,0q�6Z    �� TextWrapping$
 Wrap=�6n   $�� ��6�   $	��Top=�6�   $	��113��6�   �� 5   
   -   5        $ textBoxPatientLastName��5      $
��Left=�62   $��22��6M   $��
370,84,0,0q�6Y   $
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $	��112��6�   �� 5   
   -   5        $ 	textBlock��5      $
��Left=�6'   $��
117,84,0,0q�6B   $
��Wrap=�6V   $��Enter Patient Name: ��6j   $	��Top=�6�   �� 5   
   -   5         ��Name$ button��5      $��Search Patients��6!   $
��Left=�6;   $��
511,84,0,0q�6V   $	��Top=�6j   $��95��6�   $��22��6�   �� 5   
   -   5        $ textBoxTrials��5      $
��Left=�6)   $��23��6D   $��245,146,0,0q�6P   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��237��6�   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��117,147,0,0q�6C   $
��Wrap=�6X   $��Enter Trial Name:��6l   $	��Top=�6�   �� 5   
   -	   5        $ button1��5      $��Search Trials��6"   $
��Left=�6:   $��511,146,0,0q�6U   $	��Top=�6j   $��95��6�   $��23��6�   �� 5   
   -
   5        $ 
textBlock2��5      $
��Left=�6(   $��154,115,0,0q�6C   $
��Wrap=�6X   $��OR��6l   $	��Top=�6v   $��17��6�   $��18��6�    J� RenderTransformOrigin$ 0.417,0.558&�6�   �� 5   
   -   5        $ 
textBlock3��5      $
��Left=�6(   $��
245,61,0,0q�6C   $
��Wrap=�6W   $��First Name:��6k   $	��Top=�6~   �� 5   
   -   5        $ textBlockLast��5      $
��Left=�6+   $��
370,61,0,0q�6F   $
��Wrap=�6Z   $��
Last Name:��6n   $	��Top=�6�   �� 5   
   -   5        $ 
textBlock4��5      $
��Left=�6(   $��253,125,0,0q�6C   $
��Wrap=�6X   $��Trail Name:��6l   $	��Top=�6   �� 5   
   -   5        $ 
buttonHome��5      $
��Home��6%   $
��Left=�6N   $��	10,10,0,0q�6i   $	��Top=�6|   $��75��6�   5      5      