using System.IO;
using System.Text;

// 파일 저장/ 로드 포맷정해주는 클래스
public class FileManager
{
    public void Save(string _path, int _rowCnt, int _colCnt, int[][] _mapInfo)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(_rowCnt);
        sb.Append(',');
        sb.Append(_colCnt);
        sb.Append(',');
        for (int row = 0; row < _rowCnt; row++)
        {
            for (int col = 0; col < _colCnt; col++)
            {
                sb.Append(_mapInfo[row][col]);
                sb.Append(',');
            }
        }
        // 상대 경로로써, vs프로젝트 파일이 있는 곳에 저장된다.
        File.WriteAllText(_path, sb.ToString());// 파일 이름, 저장 내용
    }
    public void Load(string _path, out int _rowCnt, out int _colCnt, out int[][] _mapInfo)
    {
        // ref와 달리 out으로 들어온 매개변수는 함수 내부에서 무조건 값을 넣어줘야 한다.
        string read = File.ReadAllText(_path);
        string[] split = read.Split(',');

        _rowCnt = int.Parse(split[0]);
        _colCnt = int.Parse(split[1]);

        _mapInfo = new int[_rowCnt][];
        for( int row = 0; row<_rowCnt; row++)
        {
            _mapInfo[row] = new int[_colCnt];
            for( int col = 0; col<_colCnt; col++)
            {
                _mapInfo[row][col] = int.Parse(split[2 + (row*_colCnt + col)]);
            }
        }
    }
} // end of class FileManager

