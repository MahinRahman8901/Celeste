#Mahin Rahman
#Final Year Project


import cv2
from cvzone.HandTrackingModule import HandDetector
import socket

height = 1920
width  = 1080

#Webcam Section
vid_cap = cv2.VideoCapture(0) #Gets the camera device
vid_cap.set(3,height)#Sets Width
vid_cap.set(4,width)#Sets height

#Hand Detector Section
detector = HandDetector(maxHands=1, detectionCon=0.7) #checks that there is one hand and that its confident that is is actually a hand

#Encoding
comm = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)#Uses UDP to find address
serverAddressPort = ("127.0.0.1", 333)

while True:
    #Displays Webcam
    success, img = vid_cap.read()#stores the video into thhe variable

    landmark_Data = []
    #Finds Hands
    hands, img  = detector.findHands(img)
    #landmark values is equal to x/y/z multiplied by 21 = 63
    if hands:
        hand = hands[0]
        lmList = hand['lmList']#Creates a dictionary that stores all landmark values to the variable
        print(lmList)
        for i in lmList:
            landmark_Data.extend([i[0],height-i[1], i[2]])# extends all the data from the dictionary into landmark data array
            # Unity uses reverse parameters meaning we have to minus the height from the data in order to reverse it

        comm.sendto(str.encode(str(landmark_Data)), serverAddressPort)#Sends the data to the address and port number

    img = cv2.resize(img,(0,0), None, .5, .5)
    cv2.imshow("Image", img)  #displays video wwith image as title
    cv2.waitKey(1)



