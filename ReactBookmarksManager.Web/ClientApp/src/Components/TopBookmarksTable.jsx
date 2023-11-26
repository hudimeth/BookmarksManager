import React from 'react';
import TopBookmarkRow from './TopBookmarkRow';

const TopBookmarksTable = ({topBookmarks }) => {
    return (
        <div className='container mt-2'>
        <table className = 'table table-hover table-bordered table-striped mt-4' >
                <thead>
                    <tr>
                        <th>Url</th>
                        <th>Count</th>
                    </tr>
                </thead>
                <tbody>
                    {topBookmarks.map(b => <TopBookmarkRow key={b.url} url={ b.url} count={b.count }/>)}
                </tbody>
            </table >
        </div>
        )
}
export default TopBookmarksTable;