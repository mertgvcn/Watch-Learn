import { RootState } from "../../app/store";

export const selectIsAttendedToCourse = (state: RootState) => state.currentStudent.isAttendedToCourse
export const selectStudentLoading = (state: RootState) => state.currentStudent.loading