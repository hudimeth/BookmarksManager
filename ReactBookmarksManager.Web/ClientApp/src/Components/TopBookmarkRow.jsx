import react from 'react';

const TopBookmarkRow = ({ url, count }) => {
    return (
        <tr>
            <td><a target='_blank' href={url}>{url }</a></td>
            <td>{count }</td>
        </tr>
    )
}

export default TopBookmarkRow;