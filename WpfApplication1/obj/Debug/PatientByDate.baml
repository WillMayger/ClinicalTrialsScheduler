   M S B A M L   `   `   `  ����I  ENHSApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NHSApplicationNHSApplication  5   	   "    NHSApplication.PatientByDate   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:NHSApplication     5   	     � Title$  Clinical Trials Scheduler��5   	   $	��550��6+   $	��725��68   $	��750��6D   $	��550��6S   $	��750��6c   $	��550��6r   ���	#FFB9F9B9.��5	      � .+�5
   
   �� -   5         ��Name$ clinicalTrialsScheduler��5
      $��210,10,222,0q�65   $
��Wrap=�6K   $��Clinical Trials Scheduler��6_   $	��Top=�6�   $��26.667(�6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6%   $��
10,184,0,0q�6@   $	��Top=�6T   $	��325��6l   $	��710��6y   ���	#FFB891F06�   �� 5   
   -   5         ��Name$ 
buttonHome��5      $
��Home��6%   $
��Left=�6N   $��	10,10,0,0q�6i   $	��Top=�6|   $��75��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ fromDate��5      $
��Left=�6'   $��
210,84,0,0q�6B   $	��Top=�6V     5   
   -   5        $ toDate��5      $
��Left=�6%   $��
418,84,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ 	textBlock��5      $
��Left=�6'   $��
210,59,0,0q�6B   $
��Wrap=�6V   $��From :��6j   $	��Top=�6x   �� 5   
   -   5        $ textBlock_Copy��5      $
��Left=�6,   $��
418,59,0,0q�6G   $
��Wrap=�6[   $
��To :��6o   $	��Top=�6{   �� 5   
   -   5        $ searchPatients��5      $��Search��6)   $
��Left=�6:   $��210,133,0,0q�6U   $	��Top=�6j   $	��310��6�   $��37��6�   6�   5      5      