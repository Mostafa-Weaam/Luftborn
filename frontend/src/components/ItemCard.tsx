import React, { useState } from 'react';
import { Item } from '../types/Item';
import { deleteItem } from '../services/itemService';

interface ItemCardProps {
  item: Item;
  onEdit: (item: Item) => void;
  onDelete: (id: string) => void;
}

const ItemCard: React.FC<ItemCardProps> = ({ item, onEdit, onDelete }) => {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleDelete = async () => {
    if (window.confirm('Are you sure you want to delete this item?')) {
      setLoading(true);
      setError(null);

      try {
        await deleteItem(item.id);
        onDelete(item.id);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Failed to delete item');
      } finally {
        setLoading(false);
      }
    }
  };

  return (
    <div className="item-card">
      <div className="item-header">
        <h3 className="item-title">{item.title}</h3>
        <div className="item-actions">
          <button 
            onClick={() => onEdit(item)}
            disabled={loading}
            className="btn btn-edit"
            title="Edit item"
          >
            ✏️
          </button>
          <button 
            onClick={handleDelete}
            disabled={loading}
            className="btn btn-delete"
            title="Delete item"
          >
            🗑️
          </button>
        </div>
      </div>
      
      <div className="item-content">
        <p className="item-description">{item.description}</p>
      </div>

      <div className="item-meta">
        <small className="item-id">ID: {item.id}</small>
      </div>

      {error && (
        <div className="error-message">
          {error}
        </div>
      )}
    </div>
  );
};

export default ItemCard;