using System.IO;
using System.Text;

// ���� ����/ �ε� ���������ִ� Ŭ����
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
        // ��� ��ην�, vs������Ʈ ������ �ִ� ���� ����ȴ�.
        File.WriteAllText(_path, sb.ToString());// ���� �̸�, ���� ����
    }
    public void Load(string _path, out int _rowCnt, out int _colCnt, out int[][] _mapInfo)
    {
        // ref�� �޸� out���� ���� �Ű������� �Լ� ���ο��� ������ ���� �־���� �Ѵ�.
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

