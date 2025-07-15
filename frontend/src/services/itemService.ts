import { Item, CreateItemRequest, UpdateItemRequest, ApiResponse, GetAllItemsResponse } from '../types/Item';

const API_BASE_URL = 'https://localhost:7243/api/item'; // Default ASP.NET Core HTTPS port

// Generic API call function
async function apiCall<T>(url: string, options: RequestInit = {}): Promise<ApiResponse<T>> {
  try {
    const response = await fetch(url, {
      ...options,
      headers: {
        'Content-Type': 'application/json',
        ...options.headers,
      },
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    const data = await response.json();
    return data;
  } catch (error) {
    console.error('API call error:', error);
    throw error;
  }
}

// Get all items
export async function getAllItems(): Promise<Item[]> {
  const response = await apiCall<GetAllItemsResponse>(`${API_BASE_URL}`);
  return response.data.items || [];
}

// Get item by ID
export async function getItemById(id: string): Promise<Item> {
  const response = await apiCall<Item>(`${API_BASE_URL}/${id}`);
  return response.data;
}

// Create new item
export async function createItem(item: CreateItemRequest): Promise<Item> {
  const response = await apiCall<Item>(`${API_BASE_URL}`, {
    method: 'POST',
    body: JSON.stringify(item),
  });
  return response.data;
}

// Update existing item
export async function updateItem(id: string, item: UpdateItemRequest): Promise<Item> {
  const response = await apiCall<Item>(`${API_BASE_URL}/${id}`, {
    method: 'PUT',
    body: JSON.stringify(item),
  });
  return response.data;
}

// Delete item
export async function deleteItem(id: string): Promise<void> {
  await apiCall<void>(`${API_BASE_URL}/${id}`, {
    method: 'DELETE',
  });
}