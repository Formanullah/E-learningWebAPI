import { Video } from './video';

export interface Topic {
    id: number;
    name: string;
    chapterName: string;
    chapterId: number;
    createdDate: Date;
    updateDate: Date;
    subjctName: string;
    className: string;
    subjectIdInClass: number;
    classId: number;
    videos?: Video[];
}
