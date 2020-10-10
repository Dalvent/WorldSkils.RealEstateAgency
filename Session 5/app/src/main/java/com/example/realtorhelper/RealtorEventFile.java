package com.example.realtorhelper;

import android.os.Build;
import android.os.Environment;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.annotation.RequiresApi;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

public class RealtorEventFile {
//    private ArrayList<RealtorEvent> realtors;
//    private String filePath;
//
//    private static final int START_TIME_INDEX = 0;
//    private static final int TYPE_INDEX = 1;
//    private static final int DURACTION_INDEX = 2;
//    private static final int COMMENT_INDEX = 3;
//
//    @RequiresApi(api = Build.VERSION_CODES.O)
//    public RealtorEventFile(String filePath) {
//        this.filePath = filePath;
//        update();
//    }
//
//    public List<RealtorEvent> getRealtors() {
//        return realtors;
//    }
//
//    @RequiresApi(api = Build.VERSION_CODES.O)
//    public void update() {
//        readRealtorEvents();
//    }
//    public void save() {
//        StringBuilder builder = new StringBuilder();
//
//        FileWriter outputStream = null;
//        try {
//            outputStream = new FileWriter(filePath, false);
//            for (RealtorEvent realtor : realtors) {
//                builder.append(convertRealtorEventToString(realtor) + "\r");
//            }
//            outputStream.write(builder.toString());
//        } catch (IOException e) {
//            e.printStackTrace();
//        }
//    }
//
//    @RequiresApi(api = Build.VERSION_CODES.O)
//    private void readRealtorEvents() {
//        realtors = new ArrayList<RealtorEvent>();
//        FileInputStream inputStream = null;
//        try {
//            inputStream = new FileInputStream(filePath);
//            InputStreamReader inputStreamReader = new InputStreamReader(inputStream);
//            BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
//            String receiveString = "";
//
//            while ( (receiveString = bufferedReader.readLine()) != null ) {
//                realtors.add(convertStringToRealtorEvent(receiveString));
//            }
//        } catch (FileNotFoundException e) {
//            e.printStackTrace();
//        } catch (IOException e) {
//            e.printStackTrace();
//        }
//        finally {
//            try {
//                inputStream.close();
//            } catch (IOException e) {
//                e.printStackTrace();
//            }
//        }
//    }
//    @RequiresApi(api = Build.VERSION_CODES.O)
//    private RealtorEvent convertStringToRealtorEvent(String stringEvent) {
//        RealtorEvent event = new RealtorEvent();
//        String[] splitedStringEvent = stringEvent.split(";");
//
//        event.setStartTime(LocalDateTime.parse(splitedStringEvent[START_TIME_INDEX]));
//        event.setEventType(RealtorEventType.valueOf(splitedStringEvent[TYPE_INDEX]));
//        event.setDuration(LocalTime.parse(splitedStringEvent[DURACTION_INDEX]));
//        event.setComment(splitedStringEvent[COMMENT_INDEX]);
//
//        return event;
//    }
//    private String convertRealtorEventToString(RealtorEvent event) {
//        StringBuilder stringBuilder = new StringBuilder();
//        stringBuilder.append(event.getStartTime().toString())
//            .append(";")
//            .append(event.getEventType().toString())
//            .append(";")
//            .append(event.getDuration().toString())
//            .append(";")
//            .append(event.getComment());
//        return stringBuilder.toString();
//    }
}
