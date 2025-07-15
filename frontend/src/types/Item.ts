export interface Item {
  id: string;
  title: string;
  description: string;
}

export interface CreateItemRequest {
  title: string;
  description: string;
}

export interface UpdateItemRequest {
  id: string;
  title: string;
  description: string;
}

export interface ApiResponse<T> {
  data: T;
  success: boolean;
  message?: string;
}