export function formatDuration(timeSpan: string) {
    const [hours, minutes, seconds] = timeSpan.split(':').map(Number);

    let formattedDuration = "";

    if (hours > 0) {
        formattedDuration += `${hours} hour${hours > 1 ? 's' : ''}`;
    }

    if (minutes > 0) {
        if (formattedDuration) {
            formattedDuration += ` `;
        }
        formattedDuration += `${minutes} minute${minutes > 1 ? 's' : ''}`;
    }

    return formattedDuration;
}