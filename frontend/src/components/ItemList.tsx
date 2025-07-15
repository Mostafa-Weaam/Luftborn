import React from 'react';
import { Item } from '../types/Item';
import ItemCard from './ItemCard';

interface ItemListProps {
  items: Item[];
  loading: boolean;
  error: string | null;
  onEdit: (item: Item) => void;
  onDelete: (id: string) => void;
}

const ItemList: React.FC<ItemListProps> = ({ 
  items, 
  loading, 
  error, 
  onEdit, 
  onDelete 
}) => {
  if (loading) {
    return (
      <div className="loading-container">
        <div className="loading-spinner"></div>
        <p>Loading items...</p>
      </div>
    );
  }

  if (error) {
    return (
      <div className="error-container">
        <div className="error-message">
          <h3>Error loading items</h3>
          <p>{error}</p>
        </div>
      </div>
    );
  }

  if (items.length === 0) {
    return (
      <div className="empty-state">
        <h3>No items found</h3>
        <p>Create your first item to get started!</p>
      </div>
    );
  }

  return (
    <div className="item-list">
      <h2>Items ({items.length})</h2>
      <div className="items-grid">
        {items.map(item => (
          <ItemCard
            key={item.id}
            item={item}
            onEdit={onEdit}
            onDelete={onDelete}
          />
        ))}
      </div>
    </div>
  );
};

export default ItemList;