import { Typography } from '@mui/material'

type OverviewType = {
    description: string
}

const Overview = ({description}: OverviewType) => {
    return (
        <Typography variant="body1">{description}</Typography>
    )
}

export default Overview