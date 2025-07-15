import axios from 'axios';
import { Item, CreateItemRequest, UpdateItemRequest, ApiResponse } from '../types/Item';

const API_BASE_URL = 'https://localhost:5001/api'; // Adjust port as needed

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Add response interceptor to handle the API response format
api.interceptors.response.use(
  (response) => response,
  (error) => {
    console.error('API Error:', error);
    return Promise.reject(error);
  }
);

export const itemService = {
  // Get all items
  getAll: async (): Promise<Item[]> => {
    try {
      const response = await api.get<ApiResponse<Item[]>>('/item');
      return response.data.data || [];
    } catch (error) {
      console.error('Error fetching items:', error);
      throw error;
    }
  },

  // Get item by ID
  getById: async (id: string): Promise<Item> => {
    try {
      const response = await api.get<ApiResponse<Item>>(`/item/${id}`);
      return response.data.data;
    } catch (error) {
      console.error('Error fetching item:', error);
      throw error;
    }
  },

  // Create new item
  create: async (item: CreateItemRequest): Promise<Item> => {
    try {
      const response = await api.post<ApiResponse<Item>>('/item', item);
      return response.data.data;
    } catch (error) {
      console.error('Error creating item:', error);
      throw error;
    }
  },

  // Update existing item
  update: async (id: string, item: UpdateItemRequest): Promise<Item> => {
    try {
      const response = await api.put<ApiResponse<Item>>(`/item/${id}`, item);
      return response.data.data;
    } catch (error) {
      console.error('Error updating item:', error);
      throw error;
    }
  },

  // Delete item
  delete: async (id: string): Promise<void> => {
    try {
      await api.delete(`/item/${id}`);
    } catch (error) {
      console.error('Error deleting item:', error);
      throw error;
    }
  },
};

export default itemService;