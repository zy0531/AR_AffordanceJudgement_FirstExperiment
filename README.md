# AR_AffordanceJudgement_FirstExperiment

## Introduction
This project is to explore human affordance judgement in mobile AR and how cognitive cue influence affordance judgement in Real World and in AR condition.  

<img src="https://raw.githubusercontent.com/zy0531/AR_AffordanceJudgement_FirstExperiment/master/Capture/trial%20procedure.png" width="500" height="300"/>

This is a preliminary experiment to figure out how the cues of shoulder width impact the affordance judgement of passing through the aperture. Specifically, participants are instructed to adjust the two poles in front of them until they thought it is the smallest width that they could walk through without turning their shoulder. This is a between-subject experiment. Each group of subjects are given a cue with the size of a ratio to his/her shoulder width. The ratios are 0.8, 1.0 and 1.2. Figures below show cues in three ratio of a 0.45m shoulder width. 

<img src="https://raw.githubusercontent.com/zy0531/AR_AffordanceJudgement_FirstExperiment/master/Capture/AJFirstCueS.jpg" width="150" height="300"/>    <img src="https://raw.githubusercontent.com/zy0531/AR_AffordanceJudgement_FirstExperiment/master/Capture/AJFirstCueE.jpg" width="150" height="300"/>    <img src="https://raw.githubusercontent.com/zy0531/AR_AffordanceJudgement_FirstExperiment/master/Capture/AJFirstCueL.jpg" width="150" height="300"/>

In a set of trials for one subject, he/she is first asked to complete a block of perception experience trials (PET) that consisted of four affordance judgment trials. The four affordance judgment trials consist of 2“ascending”(A) and2“descending”(D) trials, always following the same pattern: A, D, A and D. In the ascending trials, the aperture started small (70% participants’ shoulder width); In the descending trials, participants were presented with a large aperture (180% participants’ shoulder width). 

<img src="https://github.com/zy0531/AR_AffordanceJudgement_FirstExperiment/blob/master/Capture/AJFirstCueE_Ascending.jpg" width="150" height="300"/>   <img src="https://github.com/zy0531/AR_AffordanceJudgement_FirstExperiment/blob/master/Capture/AJFirstCueE_Descending.jpg" width="150" height="300"/>


Then participants are presented with outcome experience trial (OET) blocks by being given the cue. The trial procedure is the same in OET which includes four affordance judgment trials in order of A, D, A, and D.

This primary user study is to find whether there is any difference of affordance judgement when the subjects are given different cues.

## Platform
Unity 2019.2.21f1

Android 9

ARCore SDK 1.15.0

## Interaction
*1. Start the App*

Hold the smart phone upright and start the app. 

*2. Input Shoulder Width*

Input your shoulder width on upper left corner. Click on button "OK" to confrim your input.

<img src="https://github.com/zy0531/AR_AffordanceJudgement_FirstExperiment/blob/master/Capture/AJFirstCueE_InputShoulderWidth.jpg" width="150" height="300"/>

*3. Detect Surface*

Scan the environment and there will be triangular grids on the floor when the system detect that surface. Hit a specific point on the grid area and a pair of poles will show up on the point with the same x and y coordinate of your hit, but always 2m away. The width of the poles depends on the your shoulder width. The aperture starts with small width then large width.

<img src="https://github.com/zy0531/AR_AffordanceJudgement_FirstExperiment/blob/master/Capture/AJFirstCueE_Grid.jpg" width="150" height="300"/>

*4. Move Virtual Poles*

Click on button 'Inward' or 'Outward' to make the two poles change 2cm increments inward or outward every single time.  You can click the button 'Go!' when you think you have adjust the gap between two poles to right let you pass through without turning your shoulder. The system will show "[Trial #] Please hit the grid on the ground to continue the trial." 

*5. Show the Cue*

When it comes to the 4th trial, there will be a bar with your shoulder width size showing in front of you. You can use that as a cue to help you estimate the minimum gap letting you go through.

<img src="https://github.com/zy0531/AR_AffordanceJudgement_FirstExperiment/blob/master/Capture/AJFirstCueE.jpg" width="150" height="300"/>

*6. Finish*

When you complete all trials, The system will show "You've finished all trials :)" 

*7. Record the Experiment Data*

This App uses "Application.persistentDataPath" to record the experiment data.  "Application.persistentDataPath" points to points to a public directory on the device(eg./storage/emulated/0/Android/data/<packagename>/files on most devices). Files in this location are not erased by app updates. The files can still be erased by users directly.
  
<img src="https://github.com/zy0531/AR_AffordanceJudgement_FirstExperiment/blob/master/Capture/data.png" width="250" height="100"/>

## Demo Video
A whole process of this experiment.
https://drive.google.com/open?id=1-6f-raYs2eloPENyitHqLXMxYVyv8pYS
