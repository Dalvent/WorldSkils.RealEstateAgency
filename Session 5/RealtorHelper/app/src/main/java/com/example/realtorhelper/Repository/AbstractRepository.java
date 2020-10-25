package com.example.realtorhelper.Repository;

import com.example.realtorhelper.ReltorEventIOException;

import java.net.MalformedURLException;
import java.util.ArrayList;
import java.util.Collection;

public abstract class AbstractRepository<T> implements Repository<T> {
    private ArrayList<ChangeListener> updateListeners = new ArrayList<>();

    public abstract T[] getAll();
    public abstract T getById(Object id);

    @Override
    public void add(T entity) {
        callEventListers();
    }

    @Override
    public void update(T entity) {
        callEventListers();
    }

    @Override
    public void delete(T entity) {
        callEventListers();
    }

    public interface ChangeListener {
        void onChanged();
    }

    public final void addChangeListener(ChangeListener listener) {
        updateListeners.add(listener);
    }

    public final void removeChangeListener(ChangeListener listener) {
        updateListeners.remove(listener);
    }

    private final void callEventListers() {
        for (ChangeListener listener: updateListeners) {
            listener.onChanged();
        }
    }

}
