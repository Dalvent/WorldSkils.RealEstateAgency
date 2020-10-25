package com.example.realtorhelper;

import android.app.Activity;
import android.content.Context;
import android.os.Build;
import android.os.Environment;
import android.util.EventLog;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.annotation.RequiresApi;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.OutputStream;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

public class RealtorEventFile {

    private String filePath;
    private ArrayList<RealtorEvent> events = new ArrayList<>();

    public RealtorEventFile(String filePath) throws ReltorEventIOException {
        this.filePath = filePath;
        update();
    }

    public List<RealtorEvent> getEvents() {
        return events;
    }

    @RequiresApi(api = Build.VERSION_CODES.KITKAT)
    public void setFilePath(String filePath) throws ReltorEventIOException {
        this.filePath = filePath;
        update();
    }

    public void remove(RealtorEvent event) {
        events.remove(event);
    }

    @RequiresApi(api = Build.VERSION_CODES.KITKAT)
    public void saveChanges() throws ReltorEventIOException {
        try(ObjectOutputStream serializer = new ObjectOutputStream(new FileOutputStream(filePath))) {
            serializer.writeObject(events);
        }
        catch (IOException e) {
            throw new ReltorEventIOException(e.getMessage());
        }
    }
    @RequiresApi(api = Build.VERSION_CODES.KITKAT)
    public void update() throws ReltorEventIOException {
        try(ObjectInputStream deserializer = new ObjectInputStream(new FileInputStream(filePath))) {
            events = (ArrayList<RealtorEvent>)deserializer.readObject();
        }
        catch (IOException e) {
            throw new ReltorEventIOException(e.getMessage());
        }
        catch (ClassCastException e) {
            new File(filePath).delete();
        }
        catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
}
