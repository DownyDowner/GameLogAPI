import axios from "axios";
import { PlatformList, PlatformListDTO } from "../models/PlatformList";

const API_BASE_URL = "https://localhost:7273";

const instance = axios.create({
  baseURL: API_BASE_URL,
  timeout: 1000,
});

export const getPlatforms = async () => {
  try {
    const response = await instance.get<PlatformListDTO[]>("/platforms");
    return response.data.map((e) => new PlatformList(e));
  } catch (error) {
    console.error("Error fetching data: ", error);
    throw error;
  }
};
