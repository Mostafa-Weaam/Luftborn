import React, { useState, useEffect } from 'react';
import { Item, CreateItemRequest } from '../types/Item';
import { createItem, updateItem } from '../services/itemService';

interface ItemFormProps {
  item?: Item;
  onSave: (item: Item) => void;
  onCancel: () => void;
}

const ItemForm: React.FC<ItemFormProps> = ({ item, onSave, onCancel }) => {
  const [title, setTitle] = useState(item?.title || '');
  const [description, setDescription] = useState(item?.description || '');
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (item) {
      setTitle(item.title);
      setDescription(item.description);
    }
  }, [item]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setError(null);

    try {
      if (item) {
        // Update existing item
        const updatedItem = await updateItem(item.id, {
          id: item.id,
          title,
          description,
        });
        onSave(updatedItem);
      } else {
        // Create new item
        const newItem = await createItem({
          title,
          description,
        });
        onSave(newItem);
      }
    } catch (err) {
      setError(err instanceof Error ? err.message : 'An error occurred');
    } finally {
      setLoading(false);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="item-form">
      <h3>{item ? 'Edit Item' : 'Create New Item'}</h3>
      
      {error && (
        <div className="error-message">
          {error}
        </div>
      )}

      <div className="form-group">
        <label htmlFor="title">Title:</label>
        <input
          id="title"
          type="text"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          required
          disabled={loading}
          className="form-input"
        />
      </div>

      <div className="form-group">
        <label htmlFor="description">Description:</label>
        <textarea
          id="description"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          required
          disabled={loading}
          className="form-textarea"
          rows={4}
        />
      </div>

      <div className="form-actions">
        <button 
          type="submit" 
          disabled={loading}
          className="btn btn-primary"
        >
          {loading ? 'Saving...' : (item ? 'Update' : 'Create')}
        </button>
        <button 
          type="button" 
          onClick={onCancel}
          disabled={loading}
          className="btn btn-secondary"
        >
          Cancel
        </button>
      </div>
    </form>
  );
};

export default ItemForm;