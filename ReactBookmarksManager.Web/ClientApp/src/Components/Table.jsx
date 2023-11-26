import React, { useState } from 'react';
import axios from 'axios';

const Table = ({ bookmark, refreshBookmarks }) => {
    const { id, title, url } = bookmark;

    const [titleText, setTitleText] = useState(title);
    const [isEditMode, setIsEditMode] = useState(false);

    const onUpdateClick = async () => {
        await axios.post('/api/bookmarks/updatebookmarktitle', { bookmarkId: id, newTitle: titleText });
        setIsEditMode(false);
        await refreshBookmarks();
    }
    const onCancelClick = () => {
        setIsEditMode(false);
        setTitleText(title);
    }

    const onDeleteClick = async () => {
        await axios.post('/api/bookmarks/deletebookmark', { bookmarkId: id });
        await refreshBookmarks();
    }

    return (
        <tr>
            {!isEditMode ? <td>{title}</td> :
                <td>
                    <input className='form-control' value={titleText} onChange={(e => setTitleText(e.target.value))} />
                </td>}
            <td><a href={url} target='_blank'>{url}</a></td>
            <td>
                {!isEditMode && <button onClick={() => setIsEditMode(true)} className='btn btn-secondary'>Edit Title</button>}
                {isEditMode && <button onClick={onUpdateClick} className='btn btn-warning'>Update</button>}
                {isEditMode && <button onClick={onCancelClick} className='btn btn-info'>Cancel</button>}
                <button className='btn btn-danger m-1' onClick={onDeleteClick}>Delete</button>
            </td>
        </tr>
    )
}

export default Table;