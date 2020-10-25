package com.example.realtorhelper.Repository;

import com.example.realtorhelper.RealtorEvent;
import com.example.realtorhelper.RealtorEventFile;
import com.example.realtorhelper.ReltorEventIOException;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Collection;

public class RealtorEventFileRepository extends AbstractRepository<RealtorEvent> {
    private RealtorEventFile realtorEventFile;

    public RealtorEventFileRepository(String filePath) {
        try {
            realtorEventFile = new RealtorEventFile(filePath);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public RealtorEvent[] getAll() {
        Object[] events = realtorEventFile.getEvents().toArray();
        return Arrays.copyOf(events, events.length, RealtorEvent[].class);
    }

    @Override
    public RealtorEvent getById(Object id) {
        return realtorEventFile.getEvents().get((int)id);
    }

    @Override
    public void add(RealtorEvent entity) {
        realtorEventFile.getEvents().add(entity);
        try {
            realtorEventFile.saveChanges();
            realtorEventFile.update();
        }
        catch (ReltorEventIOException e) {
            e.printStackTrace();
        }

        super.add(entity);
    }

    @Override
    public void update(RealtorEvent entity) {
        // TODO: Impliment
        throw new UnsupportedOperationException("Not implimented");
    }

    @Override
    public void delete(RealtorEvent entity)  {
        realtorEventFile.getEvents().remove(entity);
        try {
            realtorEventFile.saveChanges();
            realtorEventFile.update();
        } catch (ReltorEventIOException e) {
            e.printStackTrace();
        }

        super.delete(entity);
    }
}
