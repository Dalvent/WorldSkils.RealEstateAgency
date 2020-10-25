package com.example.realtorhelper.Repository;

import android.annotation.SuppressLint;
import android.os.AsyncTask;
import android.os.Build;
import android.util.Log;

import androidx.annotation.RequiresApi;

import com.example.realtorhelper.RealtorEvent;
import com.example.realtorhelper.ResponseRealtorEvent;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.concurrent.ExecutionException;

public class RealtorEventApiRepository extends AbstractRepository<RealtorEvent> {
    private static final String REALTOR_EVENT_URL = "http://10.0.2.2:52979/api/RealtorEvents/";
    private static final int realtorId = 1;
    @SuppressLint("LongLogTag")
    @Override
    public RealtorEvent[] getAll() {
        RealtorEvent[] result = null;
        try {
            result = new GetRealtorEventsByRealtor(realtorId).execute().get();
        } catch (ExecutionException | InterruptedException e) {
            e.printStackTrace();
        }
        return result;
    }

    @Override
    public RealtorEvent getById(Object id) {
        //TODO: IMPLIMENT;
        return null;
    }

    @Override
    public void add(RealtorEvent entity) {
        ResponseRealtorEvent responseEntity = new ResponseRealtorEvent(realtorId, entity);
        try {
            new PostRealtorEvents(responseEntity).execute().get();
        }
        catch (ExecutionException | InterruptedException e) {
            e.printStackTrace();
        }
        super.add(entity);
    }

    @Override
    public void update(RealtorEvent entity) {
        // TODO: IMPLIMENT.
        super.update(entity);
    }

    @RequiresApi(api = Build.VERSION_CODES.M)
    @Override
    public void delete(RealtorEvent entity) {
        ResponseRealtorEvent response = (ResponseRealtorEvent) entity;
        try {
            new DeleteRealtorEvents(response.getUuid()).execute().get();
        }
        catch (ExecutionException | InterruptedException e) {
            e.printStackTrace();
        }
        super.delete(entity);
    }

    private class GetRealtorEvents extends AsyncTask<Void, Void, RealtorEvent[]> {
        @Override
        protected RealtorEvent[] doInBackground(Void... voids) {
            return convertJsonToRealtorEvents(getJson());
        }

        private String getJson() {
            HttpURLConnection connection = null;
            BufferedReader reader = null;
            try {
                URL url = new URL(RealtorEventApiRepository.REALTOR_EVENT_URL);
                connection = (HttpURLConnection) url.openConnection();
                connection.connect();
                InputStream stream = connection.getInputStream();
                reader = new BufferedReader(new InputStreamReader(stream));

                StringBuffer buffer = new StringBuffer();
                String line = "";

                while ((line = reader.readLine()) != null) {
                    buffer.append(line + "\n");
                    Log.d("Response: ", "> " + line);
                }

                return buffer.toString();
            }
            catch (MalformedURLException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            }
            finally {
                if (connection != null) {
                    connection.disconnect();
                }
                try {
                    if (reader != null) {
                        reader.close();
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
            return null;
        }
        private RealtorEvent[] convertJsonToRealtorEvents(String jsonString) {
            ArrayList<RealtorEvent> realtorEvents = new ArrayList<>();
            try {
                JSONArray tempArray = new JSONArray(jsonString);
                for (int i = 0; i < tempArray.length(); i++) {
                    JSONObject realtorEventJson = tempArray.getJSONObject(i);
                    ResponseRealtorEvent tempEvent = new ResponseRealtorEvent(
                            realtorEventJson.getString("Uuid"),
                            realtorEventJson.getInt("RealtorId"),
                            realtorEventJson.getLong("StartDateTime"),
                            realtorEventJson.getString("Type"),
                            realtorEventJson.getLong("Duration"),
                            realtorEventJson.getString("Comment")
                    );
                    realtorEvents.add(tempEvent);
                }
            }
            catch (JSONException e) {
                e.printStackTrace();
            }
            Object[] objectArray = realtorEvents.toArray();
            return  Arrays.copyOf(objectArray, objectArray.length, RealtorEvent[].class);
        }
    }
    private class GetRealtorEventsByRealtor extends AsyncTask<Void, Void, RealtorEvent[]> {
        private int realtorId;
        GetRealtorEventsByRealtor(int realtorId) {
            this.realtorId = realtorId;
        }

        @Override
        protected RealtorEvent[] doInBackground(Void... voids) {
            return convertJsonToRealtorEvents(getJson());
        }

        private String getJson() {
            HttpURLConnection connection = null;
            BufferedReader reader =h null;
            try {
                URL url = new URL(RealtorEventApiRepository.REALTOR_EVENT_URL + "/" + realtorId);
                connection = (HttpURLConnection) url.openConnection();
                connection.connect();
                InputStream stream = connection.getInputStream();
                reader = new BufferedReader(new InputStreamReader(stream));

                StringBuffer buffer = new StringBuffer();
                String line = "";

                while ((line = reader.readLine()) != null) {
                    buffer.append(line + "\n");
                    Log.d("Response: ", "> " + line);
                }

                return buffer.toString();
            }
            catch (MalformedURLException e) {
                e.printStackTrace();
            } catch (IOException e) {
                e.printStackTrace();
            }
            finally {
                if (connection != null) {
                    connection.disconnect();
                }
                try {
                    if (reader != null) {
                        reader.close();
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
            return null;
        }
        private RealtorEvent[] convertJsonToRealtorEvents(String jsonString) {
            ArrayList<RealtorEvent> realtorEvents = new ArrayList<>();
            try {
                JSONArray tempArray = new JSONArray(jsonString);
                for (int i = 0; i < tempArray.length(); i++) {
                    JSONObject realtorEventJson = tempArray.getJSONObject(i);
                    ResponseRealtorEvent tempEvent = new ResponseRealtorEvent(
                            realtorEventJson.getString("Uuid"),
                            realtorEventJson.getInt("RealtorId"),
                            realtorEventJson.getLong("StartDateTime"),
                            realtorEventJson.getString("Type"),
                            realtorEventJson.getLong("Duration"),
                            realtorEventJson.getString("Comment")
                    );
                    realtorEvents.add(tempEvent);
                }
            }
            catch (JSONException e) {
                e.printStackTrace();
            }
            Object[] objectArray = realtorEvents.toArray();
            return  Arrays.copyOf(objectArray, objectArray.length, RealtorEvent[].class);
        }
    }
    private class PostRealtorEvents extends AsyncTask<Void, Void, Void> {
        private ResponseRealtorEvent postRealtorEvent;
        PostRealtorEvents(ResponseRealtorEvent postRealtorEvent) {
            this.postRealtorEvent = postRealtorEvent;
        }

        @Override
        protected Void doInBackground(Void... voids) {
            sendJson(convertToJson(postRealtorEvent));
            return null;
        }

            private String convertToJson(ResponseRealtorEvent responseRealtorEvent) {
            JSONObject realtorEventJson = new JSONObject();
            try {
                realtorEventJson.put("Uuid", responseRealtorEvent.getUuid());
                realtorEventJson.put("RealtorId", responseRealtorEvent.getRealtorId());
                realtorEventJson.put("StartDateTime", responseRealtorEvent.getStartDateTime().getTimeInMillis());
                realtorEventJson.put("Type", responseRealtorEvent.getEventTypeString());
                realtorEventJson.put("Duration", responseRealtorEvent.getDuraction().getTime());
                realtorEventJson.put("Comment", responseRealtorEvent.getComment());
            }
            catch (JSONException e) {
                e.printStackTrace();
            }

            return realtorEventJson.toString();
        }

        private void sendJson(String json) {
            try {
                URL url = new URL(REALTOR_EVENT_URL);
                HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
                urlConnection.setRequestMethod("POST");
                urlConnection.setRequestProperty("Content-Type", "application/json; utf-8");
                urlConnection.setRequestProperty("Accept", "application/json");
                urlConnection.setDoOutput(true);

                OutputStream outputStream = urlConnection.getOutputStream();
                byte[] input = json.getBytes("utf-8");
                outputStream.write(input, 0, input.length);

                try(BufferedReader br = new BufferedReader(
                        new InputStreamReader(urlConnection.getInputStream(), "utf-8"))) {
                    StringBuilder response = new StringBuilder();
                    String responseLine = null;
                    while ((responseLine = br.readLine()) != null) {
                        response.append(responseLine.trim());
                    }
                    System.out.println(response.toString());
                }

                urlConnection.connect();
            } catch (Exception e) {
                System.out.println(e.getMessage());
            }
        }
    }
    private class DeleteRealtorEvents extends AsyncTask<Void, Void, Void> {
        private String deleteEntityId;
        DeleteRealtorEvents(String deleteEntityId) {
            this.deleteEntityId = deleteEntityId;
        }

        @Override
        protected Void doInBackground(Void... voids) {
            OutputStream out = null;
            try {
                URL url = new URL(REALTOR_EVENT_URL + "/" + deleteEntityId);
                HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
                urlConnection.setRequestProperty("Content-Type", "application/x-www-form-urlencoded" );
                urlConnection.setRequestMethod("DELETE");
                urlConnection.setUseCaches(false);
                urlConnection.setDoInput(true);
                urlConnection.setDoOutput(true);
                int responseCode = urlConnection.getResponseCode();
            } catch (Exception e) {
                System.out.println(e.getMessage());
            }

            return null;
        }
    }
}