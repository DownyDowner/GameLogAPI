import axios from "axios";

const API_BASE_URL = "https://localhost:7273";

const instance = axios.create({
  baseURL: API_BASE_URL,
  timeout: 1000,
});

export const getPlatforms = async () => {
  try {
    const response = await instance.get("/platforms");
    return response.data;
  } catch (error) {
    console.error("Error fetching data: ", error);
    throw error;
  }
};
