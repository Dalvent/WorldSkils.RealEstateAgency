package com.example.realtorhelper.Repository;

import com.example.realtorhelper.ReltorEventIOException;

import java.net.MalformedURLException;
import java.util.Collection;

public interface Repository<T> {
    T[] getAll();
    T getById(Object id);
    void add(T entity) throws ReltorEventIOException;
    void update(T entity);
    void delete(T entity) throws ReltorEventIOException, MalformedURLException;
}
